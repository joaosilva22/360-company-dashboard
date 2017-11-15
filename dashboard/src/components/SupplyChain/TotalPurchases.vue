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
  props: ['year'],
  created() {
    this.totalPurchases().then((res) => {
      this.items = [
        {
          name: 'Total Number',
          value: res.data.TotalCompras,
        },
        {
          name: 'Total Value',
          value: `${this.formatVal(res.data.TotalValor)} EUR`,
        },
      ];
    });
  },
  methods: {
    totalPurchases() {
      return Purchases.totalPurchases();
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
