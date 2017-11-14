<template>
  <box title="Average Sale Value" :items="items"></box>
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
       const totalValue = res.data.TotalCredit;
       const totalNumber = res.data.NumberOfEntries;
       const average = totalValue / totalNumber;
       this.items = [{ name: '', value: this.formatVal(average) }];
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
