
export default {
  totalSales() {
    return this.$axios.get('total-sales');
  },
  averageSaleValue() {
    return this.$axios.get('average-sale-value');
  },
  salesInvoices() {
    return this.$axios.get('sales-invoices');
  },
  customers() {
    return this.$axios.get('customers');
  },
  customer(customerId) {
    return this.$axios.get(`customers/${customerId}`);
  },
  customerNetValue(customerId) {
    return this.$axios.get(`customers/${customerId}/net-value`);
  },
};
