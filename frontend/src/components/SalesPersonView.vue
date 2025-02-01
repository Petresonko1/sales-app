<template>
  <div>
    <h1>Sales Person View</h1>
    <div>
      <h2>Customer Orders</h2>
      <ul>
        <li v-for="order in orders" :key="order.id">
          Order ID: {{ order.id }} - Customer: {{ order.customerName }} - Total: {{ order.total }}
        </li>
      </ul>
    </div>
    <button @click="fetchOrders">Refresh Orders</button>
  </div>
</template>

<script>
import { grpc } from '@improbable-eng/grpc-web';
import { OrderServiceClient } from '../protos/order_pb_service';
import { GetOrdersRequest } from '../protos/order_pb';

export default {
  data() {
    return {
      orders: []
    };
  },
  methods: {
    fetchOrders() {
      const client = new OrderServiceClient('http://localhost:5000');
      const request = new GetOrdersRequest();

      client.getOrders(request, {}, (err, response) => {
        if (err) {
          console.error(err);
          return;
        }
        this.orders = response.getOrdersList();
      });
    }
  },
  mounted() {
    this.fetchOrders();
  }
};
</script>

<style scoped>
h1 {
  color: #333;
}
</style>