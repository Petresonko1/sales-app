import Vue from 'vue';
import Router from 'vue-router';
import Admin from './views/Admin.vue';
import SalesPerson from './views/SalesPerson.vue';
import Customer from './views/Customer.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/admin',
      name: 'Admin',
      component: Admin
    },
    {
      path: '/salesperson',
      name: 'SalesPerson',
      component: SalesPerson
    },
    {
      path: '/customer',
      name: 'Customer',
      component: Customer
    }
  ]
});