
export default {
  receivable() {
    return this.$axios.get('accountReceivable');
  },
};
