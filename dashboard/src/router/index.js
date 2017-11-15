import Vue from 'vue';
import Router from 'vue-router';
import Financial from '@/components/Financial/Financial';
import Overview from '@/components/Overview/Overview';
import Sales from '@/components/Sales';
import SupplyChain from '@/components/SupplyChain/SupplyChain';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'root',
      component: Overview,
    },
    {
      path: '/financial',
      name: 'financial',
      component: Financial,
    },
    {
      path: '/sales',
      name: 'sales',
      component: Sales,
    },
    {
      path: '/supplyChain',
      name: 'supplyChain',
      component: SupplyChain,
    },
  ],
});
