// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.

import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import Vue from 'vue'
import axios from 'axios'
import App from './App'
import router from './router'

const axiosConfig = {
  baseurl: 'http://192.168.1.68:49822/'
}

Vue.prototype.$axios = axios.create(axiosConfig)
Vue.config.productionTip = false

Vue.use(Vuetify)

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App }
})
