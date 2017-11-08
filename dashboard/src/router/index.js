import Vue from 'vue'
import Router from 'vue-router'
import Main from '@/components/Main'
import Financial from '@/components/Financial'
import Overview from '@/components/Overview'
import Sales from '@/components/Sales'
import SupplyChain from '@/components/SupplyChain'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'root',
      component: Main
    },
    {
      path: '/financial',
      name: 'financial',
      component: Financial
    },
    {
      path: '/overview',
      name: 'overview',
      component: Overview
    },
    {
      path: '/sales',
      name: 'sales',
      component: Sales
    },
    {
      path: '/supplyChain',
      name: 'supplyChain',
      component: SupplyChain
    }
  ]
})
