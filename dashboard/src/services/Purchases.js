
export default {
  purchasesInvoices(initialDate, endDate) {
    return this.$Primavera.get(`docCompra/VFA/${initialDate}/${endDate}`);
  },
  accountsPayable(initialDate, endDate) {
    return this.$Primavera.get(`docCompra/VFA/${initialDate}/${endDate}`);
  },
};
