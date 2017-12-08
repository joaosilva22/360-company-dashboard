<template>
  <box title="Inventory Value" :items="items"></box>
</template>

<script>
 import Box from '@/components/Box';

 export default {
   data() {
     return {
     };
   },
   props: ['items'],
   created() {
     this.inventoryValue().then((res) => {
       const totalValue = res.data;
       this.items = [{ name: 'Value', value: `${this.formatVal(totalValue)} EUR` }];
     });
   },
   methods: {
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
