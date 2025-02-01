<template>
  <div>
    <h1>Customer View</h1>
    <div>
      <h2>Available Products</h2>
      <ul>
        <li v-for="product in products" :key="product.id">
          {{ product.name }} - {{ product.price }} 
          <button @click="placeOrder(product.id)">Order</button>
        </li>
      </ul>
    </div>
    <div v-if="orderConfirmation">
      <p>Order placed successfully!</p>
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
      orderConfirmation: false,
    };
  },
  created() {
    this.fetchProducts();
  },
  methods: {
    fetchProducts() {
      const client = new ProductServiceClient('http://localhost:5000');
      const request = new GetProductsRequest();

      client.getProducts(request, {}, (err, response) => {
        if (err) {
          console.error(err);
          return;
        }
        this.products = response.getProductsList();
      });
    },
    placeOrder(productId) {
      // Logic to place an order using gRPC
      this.orderConfirmation = true;
    },
  },
};
</script>

<style scoped>
h1 {
  color: #333;
}
</style>