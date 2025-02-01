<template>
  <div>
    <h1>Sales Person Dashboard</h1>
    <SalesPersonView @orderCollected="handleOrderCollected" />
  </div>
</template>

<script>
import SalesPersonView from '../components/SalesPersonView.vue';

export default {
  components: {
    SalesPersonView,
  },
  methods: {
    handleOrderCollected(order) {
      // Logic to handle the collected order
      console.log('Order collected:', order);
    },
  },
};
</script>

<style scoped>
h1 {
  color: #333;
}
</style>