<template>
  <div>
    <h1>SupplyChain</h1>
  </div>
</template>

<script>
export default {
  data() {
    return {
      fromYear: 0,
      fromMonth: 0,
      toYear: 0,
      toMonth: 0,
    };
  },
  methods: {
    updateFromYear(value) {
      this.fromYear = value;
    },
    updateFromMonth(value) {
      this.fromMonth = value;
    },
    updateToYear(value) {
      this.toYear = value;
    },
    updateToMonth(value) {
      this.toMonth = value;
    },
  },
};
</script>

