import axios from 'axios';

export default {
  totalSales(fiscalYear) {
    return axios.get(`AuditFile/DocumentTotals?FiscalYear=${fiscalYear}`);
  },
  salesInvoices(fiscalYear) {
    return axios.get(`AuditFile/SalesInvoices?FiscalYear=${fiscalYear}`);
  },
  customers() {
    // return this.$axios.get('customers');
  },
  customer(fiscalYear, customerId) {
    return axios.get(`AuditFile/Customers?FiscalYear=${fiscalYear}&CustomerID=${customerId}`);
  },
  customerNetValue() {
    // return this.$axios.get(`customers/${customerId}/net-value`);
  },
};
