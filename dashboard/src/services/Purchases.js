import axios from 'axios';

export default {
  purchasesInvoices() {
    return axios.get('docCompra');
  },
  accountsPayable() {
    return axios.get('docCompra');
  },
  totalPurchases() {
    return axios.get('compras');
  },
};
