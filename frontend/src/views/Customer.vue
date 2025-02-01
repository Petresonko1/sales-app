<template>
  <div class="customer-view">
    <h1>Customer Dashboard</h1>
    <div>
      <h2>Available Products</h2>
      <ul>
        <li v-for="product in products" :key="product.id">
          {{ product.name }} - {{ product.price }} 
          <button @click="addToCart(product)">Add to Cart</button>
        </li>
      </ul>
    </div>
    <div>
      <h2>Your Cart</h2>
      <ul>
        <li v-for="item in cart" :key="item.id">
          {{ item.name }} - {{ item.price }} 
          <button @click="removeFromCart(item)">Remove</button>
        </li>
      </ul>
      <button @click="placeOrder">Place Order</button>
    </div>
  </div>
</template>

<script>
import { grpc } from '@improbable-eng/grpc-web';
import { ProductServiceClient } from '../protos/product_pb_service';
import { GetProductsRequest } from '../protos/product_pb';

export default {
  data() {
    return {
      products: [],
      cart: []
    };
  },
  methods: {
    fetchProducts() {
      const client = new ProductServiceClient('http://localhost:5000');
      const request = new GetProductsRequest();

      grpc.unary(ProductService.GetProducts, {
        request: request,
        host: 'http://localhost:5000',
        onEnd: (response) => {
          const { status, message } = response;
          if (status === grpc.Code.OK && message) {
            this.products = message.getProductsList();
          }
        }
      });
    },
    addToCart(product) {
      this.cart.push(product);
    },
    removeFromCart(item) {
      this.cart = this.cart.filter(cartItem => cartItem.id !== item.id);
    },
    placeOrder() {
      // Logic to place order
      alert('Order placed successfully!');
      this.cart = [];
    }
  },
  mounted() {
    this.fetchProducts();
  }
};
</script>

<style scoped>
.customer-view {
  padding: 20px;
}
</style>