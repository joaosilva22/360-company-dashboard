<template>
  <box title="Total Sales" :items="items"></box>
</template>

<script>
import Sales from '@/services/Sales';
import Box from '@/components/Box';

export default {
  data() {
    return {
      items: [],
    };
  },
  props: ['year'],
  created() {
    this.totalSales(this.year).then((res) => {
      this.items = [
        {
          name: 'Total Number',
          value: res.data.NumberOfEntries,
        },
        {
          name: 'Total Value',
          value: this.formatVal(res.data.TotalCredit),
        },
      ];
    });
  },
  methods: {
    totalSales(fiscalYear) {
      return Sales.totalSales(fiscalYear);
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
