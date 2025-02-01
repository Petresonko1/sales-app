<template>
  <div class="admin">
    <h1>Admin Dashboard</h1>
    <AdminView @userCreated="fetchUsers" @productAdded="fetchProducts" />
    <div>
      <h2>Users</h2>
      <ul>
        <li v-for="user in users" :key="user.id">{{ user.name }}</li>
      </ul>
    </div>
    <div>
      <h2>Products</h2>
      <ul>
        <li v-for="product in products" :key="product.id">{{ product.name }}</li>
      </ul>
    </div>
  </div>
</template>

<script>
import AdminView from '../components/AdminView.vue';

export default {
  components: {
    AdminView,
  },
  data() {
    return {
      users: [],
      products: [],
    };
  },
  methods: {
    fetchUsers() {
      // Logic to fetch users from the backend
    },
    fetchProducts() {
      // Logic to fetch products from the backend
    },
  },
  mounted() {
    this.fetchUsers();
    this.fetchProducts();
  },
};
</script>

<style scoped>
.admin {
  padding: 20px;
}
</style>