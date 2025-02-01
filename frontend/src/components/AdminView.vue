<template>
  <div class="admin-view">
    <h1>Admin Dashboard</h1>
    <section>
      <h2>Create User</h2>
      <form @submit.prevent="createUser">
        <input v-model="newUser.username" placeholder="Username" required />
        <input v-model="newUser.password" type="password" placeholder="Password" required />
        <button type="submit">Create User</button>
      </form>
    </section>
    <section>
      <h2>Add Product</h2>
      <form @submit.prevent="addProduct">
        <input v-model="newProduct.name" placeholder="Product Name" required />
        <input v-model="newProduct.price" type="number" placeholder="Product Price" required />
        <button type="submit">Add Product</button>
      </form>
    </section>
    <section>
      <h2>Manage Users</h2>
      <ul>
        <li v-for="user in users" :key="user.id">{{ user.username }}</li>
      </ul>
    </section>
    <section>
      <h2>Manage Products</h2>
      <ul>
        <li v-for="product in products" :key="product.id">{{ product.name }} - ${{ product.price }}</li>
      </ul>
    </section>
  </div>
</template>

<script>
import { grpc } from '@improbable-eng/grpc-web';
import { UserServiceClient } from '../protos/user_pb_service';
import { CreateUserRequest } from '../protos/user_pb';
import { ProductServiceClient } from '../protos/product_pb_service';
import { AddProductRequest } from '../protos/product_pb';

export default {
  data() {
    return {
      newUser: {
        username: '',
        password: ''
      },
      newProduct: {
        name: '',
        price: 0
      },
      users: [],
      products: []
    };
  },
  methods: {
    createUser() {
      const request = new CreateUserRequest();
      request.setUsername(this.newUser.username);
      request.setPassword(this.newUser.password);
      
      const client = new UserServiceClient('http://localhost:5000');
      client.createUser(request, {}, (err, response) => {
        if (err) {
          console.error(err);
        } else {
          this.users.push(response.getUser());
          this.newUser.username = '';
          this.newUser.password = '';
        }
      });
    },
    addProduct() {
      const request = new AddProductRequest();
      request.setName(this.newProduct.name);
      request.setPrice(this.newProduct.price);
      
      const client = new ProductServiceClient('http://localhost:5000');
      client.addProduct(request, {}, (err, response) => {
        if (err) {
          console.error(err);
        } else {
          this.products.push(response.getProduct());
          this.newProduct.name = '';
          this.newProduct.price = 0;
        }
      });
    },
    fetchUsers() {
      // Fetch users logic
    },
    fetchProducts() {
      // Fetch products logic
    }
  },
  mounted() {
    this.fetchUsers();
    this.fetchProducts();
  }
};
</script>

<style scoped>
.admin-view {
  padding: 20px;
}
</style>