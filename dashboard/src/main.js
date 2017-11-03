// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Main from '@/components/Main';
import Sales from '@/components/Sales';
import Overview from '@/components/Overview';
import Financial from '@/components/Financial';
import SupplyChain from '@/components/SupplyChain';
import Vue from 'vue';
import VueRouter from 'vue-router';
import App from './App';

Vue.use(VueRouter);

const routes = [
  { path: '/sales', component: Sales },
  { path: '/overview', component: Overview },
  { path: '/financial', component: Financial },
  { path: '/supplyChain', component: SupplyChain },
  { path: '/', component: Main },
];

const router = new VueRouter({
  routes,
});
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  render: h => h(App),
});

