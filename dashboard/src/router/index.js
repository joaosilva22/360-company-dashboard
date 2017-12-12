import Vue from 'vue';
import Router from 'vue-router';
import Financial from '@/components/Finances/Finances';
import Overview from '@/components/Overview/Overview';
import Sales from '@/components/Sales/Sales';
import SupplyChain from '@/components/SupplyChain/SupplyChain';
import DetailsDoc from '@/components/DetailsDoc';
import Customer from '@/components/Customer';
import Sale from '@/components/Sale';

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
      path: '/docVenda/:idDoc',
      name: 'detailsDoc',
      component: DetailsDoc,
    },
    {
      path: '/Customer/:year/:id',
      name: 'customer',
      component: Customer,
    },
    {
      path: '/Sale/:year/:invoiceNo',
      name: 'sale',
      component: Sale,
    },
  ],
});
