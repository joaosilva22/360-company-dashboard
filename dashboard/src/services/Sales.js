import axios from 'axios';

export default {
  totalSales() {
    return axios.get('total-sales');
  },
  averageSaleValue() {
    return axios.get('average-sale-value');
  },
  salesInvoices() {
    return axios.get('sales-invoices');
  },
  customers() {
    return axios.get('customers');
  },
  customer(customerId) {
    return axios.get(`customers/${customerId}`);
  },
  customerNetValue(customerId) {
    return axios.get(`customers/${customerId}/net-value`);
  },
};
