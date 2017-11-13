
export default {
  purchasesInvoices(initialDate, endDate) {
    return this.$axios.get(`docCompra/VFA/${initialDate}/${endDate}`);
  },
};
