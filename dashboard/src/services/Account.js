import axios from 'axios';

export default {
  receivable() {
    return this.$axios.get('accountReceivable');
  },

  currentRatio(int fiscalYear) {
  	return this.$axios.get(`AuditFile/CurrentRatio?FiscalYear=${fiscalYear}`);
  },

  incomeAndExpenses(int fiscalYear) {
  	return this.$axios.get(`AuditFile/CurrentRatio?FiscalYear=${fiscalYear}`);
  },
};
