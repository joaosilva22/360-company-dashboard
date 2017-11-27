// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.

import Vuetify from 'vuetify';
import 'vuetify/dist/vuetify.min.css';
import Vue from 'vue';
import axios from 'axios';
import moment from 'moment';

import App from './App';
import router from './router';

Vue.config.productionTip = false;
Vue.use(Vuetify);

axios.defaults.baseURL = 'http://localhost:49822/api/';
// axios.defaults.baseURL = 'http://192.168.1.68:49822/api/';
axios.defaults.headers.common['Content-Type'] = 'application/json';

Vue.filter('formatDate', (value) => {
  if (!value) return '';
  return moment(String(value)).format('YYYY/MM/DD hh:mm');
});

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App },
});
