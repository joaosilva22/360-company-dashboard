import axios from 'axios';

export default {
  purchasesInvoices(fiscalYear) {
    const endDate = fiscalYear + 1;
    return axios.get(`docCompra/${fiscalYear}/${endDate}`);
  },
  accountsPayable(initialDate, endDate) {
    return axios.get(`docCompra/VFA/${initialDate}/${endDate}`);
  },
  totalPurchases() {
    return axios.get('compras');
  },
};
