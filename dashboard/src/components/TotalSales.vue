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
   created() {
     this.totalSales().then((res) => {
       const totalNumber = res.data.totalNumber;
       const totalValue = res.data.totalValue;
       this.items = [
         {
           name: 'Total Number',
           value: totalNumber,
         },
         {
           name: 'Total Value',
           value: totalValue,
         },
       ];
     });
   },
   methods: {
     totalSales() {
       return Sales.totalSales();
     },
   },
   components: {
     Box,
   },
 };
</script>
