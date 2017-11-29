import axios from 'axios';

export default {
  totalSales(fiscalYear) {
    return axios.get(`AuditFile/DocumentTotals?FiscalYear=${fiscalYear}`);
  },
  salesInvoices(fiscalYear) {
    return axios.get(`AuditFile/SalesInvoices?FiscalYear=${fiscalYear}`);
  },
  customers(fiscalYear) {
    return axios.get(`AuditFile/Customers?FiscalYear=${fiscalYear}`);
  },
  customer(fiscalYear, customerId) {
    return axios.get(`AuditFile/Customers?FiscalYear=${fiscalYear}&CustomerID=${customerId}`);
  },
  customerNetTotal(fiscalYear, customerId) {
    return axios.get(`AuditFile/NetTotal?FiscalYear=${fiscalYear}&CustomerID=${customerId}`);
  },
  salesBacklog() {
    return axios.get('DocVenda');
  },
  invoiceLines(fiscalYear) {
    return axios.get(`AuditFile/InvoiceLines?FiscalYear=${fiscalYear}`);
  },
  accountsReceivable() {
    return axios.get('ContasAReceber');
  },
};
