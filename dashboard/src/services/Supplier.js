import axios from 'axios';

export default {
  topSuppliers(fiscalYear, endDate) {
    return axios.get(`fornecedores/${fiscalYear}/${endDate}`);
  },
};
