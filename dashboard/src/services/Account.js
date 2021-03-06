import axios from 'axios';

export default {
  receivable() {
    return axios.get('accountReceivable');
  },

  currentRatio(fiscalYear) {
    return axios.get(`AuditFile/CurrentRatio?FiscalYear=${fiscalYear}`);
  },

  incomeAndExpenses(fiscalYear) {
    return axios.get(`AuditFile/IncomeAndExpenses?FiscalYear=${fiscalYear}`);
  },
};
