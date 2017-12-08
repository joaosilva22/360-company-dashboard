<template>
  <box title="Total Purchases" :items="items"></box>
</template>

<script>
import Box from '@/components/Box';

export default {
  data() {
    return {
      items: [],
    };
  },
  props: ['totalpurchases'],
  created() {
    this.totalPurchases();
  },
  watch: {
    totalpurchases() {
      this.items = [];
      this.totalpurchases();
    },
  },
  methods: {
    formatVal(value) {
      const val = (parseFloat(value) / 1).toFixed(2).replace('.', ',');
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '.');
    },
    totalPurchases() {
      console.log(this.totalpurchases);
      this.items = [
        {
          name: 'Total Number',
          value: this.totalpurchases.TotalCompras,
        },
        {
          name: 'Total Value',
          value: `${this.formatVal(this.totalpurchases.TotalValor * -1)} EUR`,
        },
      ];
    },
  },
  components: {
    Box,
  },
};
</script>
