import axios from 'axios';

export default {
  purchasesInvoices(start, end) {
    return axios.get(`docCompra/${start}/${end}`);
  },
  accountsPayable(start, end) {
    return axios.get(`ContasAPagar/${start}/${end}`);
  },
  totalPurchases(start, end) {
    return axios.get(`compras/${start}/${end}`);
  },
};
