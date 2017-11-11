import axios from 'axios';

export default {
  totalSales() {
    return axios.get('total-sales');
  },
  averageSaleValue() {
    return axios.get('average-sale-value');
  },
};
