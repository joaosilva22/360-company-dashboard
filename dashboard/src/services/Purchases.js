import axios from 'axios';

export default {
  purchasesInvoices(fiscalYear) {
    const endDate = fiscalYear + 1;
    return axios.get(`compras/${fiscalYear}/${endDate}`);
  },
  accountsPayable(initialDate, endDate) {
    return axios.get(`docCompra/VFA/${initialDate}/${endDate}`);
  },
};
