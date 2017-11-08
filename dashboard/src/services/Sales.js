
export default{
  backloq(timeInternal) {
    return this.$axios.get('salesBackloq', timeInternal)
  }
}
