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
   created() {
     this.averageSaleValue().then((res) => {
       const average = res.data.average;
       this.items = [{ name: '', value: average }];
     });
   },
   methods: {
     averageSaleValue() {
       return Sales.averageSaleValue();
     },
   },
   components: {
     Box,
   },
 };
</script>
