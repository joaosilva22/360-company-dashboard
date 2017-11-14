import axios from 'axios';

export default {
  totalSales(fiscalYear) {
    return axios.get(`AuditFile/DocumentTotals?FiscalYear=${fiscalYear}`);
  },
  salesInvoices() {
    // return this.$axios.get('sales-invoices');
  },
  customers() {
    // return this.$axios.get('customers');
  },
  customer() {
    // return this.$axios.get(`customers/${customerId}`);
  },
  customerNetValue() {
    // return this.$axios.get(`customers/${customerId}/net-value`);
  },
};
