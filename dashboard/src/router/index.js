import Vue from 'vue';
import Router from 'vue-router';
import Financial from '@/components/Finances/Finances';
import Overview from '@/components/Overview/Overview';
import Sales from '@/components/Sales/Sales';
import SupplyChain from '@/components/SupplyChain/SupplyChain';
import DetailsDoc from '@/components/DetailsDoc';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'root',
      component: Overview,
    },
    {
      path: '/finances',
      name: 'finances',
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
    {
      path: '/detailsDoc/:idDoc',
      name: 'detailsDoc',
      component: DetailsDoc,
    },
  ],
});
