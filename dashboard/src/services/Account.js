import axios from 'axios';

export default {
  receivable() {
    return this.$axios.get('accountReceivable');
    console.log(this.currentAssets(2016));
  },

  currentRatio(int fiscalYear) {
  	return this.$axios.get(`AuditFile/CurrentRatio?FiscalYear=${fiscalYear}`);
  }
};
