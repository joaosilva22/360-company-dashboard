<template>
  <box title="Total Purchases" :items="items"></box>
</template>

<script>
import Purchases from '@/services/Purchases';
import Box from '@/components/Box';

export default {
  data() {
    return {
      items: [],
    };
  },
  props: ['start', 'end'],
  created() {
    this.totalPurchases(this.start, this.end).then((res) => {
      this.items = [
        {
          name: 'Total Number',
          value: res.data.TotalCompras,
        },
        {
          name: 'Total Value',
          value: `${this.formatVal(res.data.TotalValor * -1)} EUR`,
        },
      ];
    });
  },
  methods: {
    totalPurchases(start, end) {
      return Purchases.totalPurchases(start, end);
    },
    formatVal(value) {
      const val = (parseFloat(value) / 1).toFixed(2).replace('.', ',');
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '.');
    },
  },
  components: {
    Box,
  },
};
</script>
