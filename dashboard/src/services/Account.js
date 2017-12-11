import axios from 'axios';

export default {
  receivable() {
    return axios.get('accountReceivable');
  },
};
