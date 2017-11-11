// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.

import Vuetify from 'vuetify';
import 'vuetify/dist/vuetify.min.css';
import Vue from 'vue';
import axios from 'axios';

import App from './App';
import router from './router';

Vue.config.productionTip = false;
Vue.use(Vuetify);

axios.defaults.baseURL = 'http://localhost:3000/api/';

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App },
});
