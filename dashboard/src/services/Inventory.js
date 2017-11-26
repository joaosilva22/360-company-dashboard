import axios from 'axios';

export default {
  getInventory() {
    return axios.get('artigos');
  },
};
