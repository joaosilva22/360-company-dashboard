<template>
  <box title="Inventory Value" :items="items"></box>
</template>

<script>
 import Box from '@/components/Box';

 export default {
   props: ['inventoryvalue'],
   data() {
     return {
       items: [],
     };
   },
   created() {
     this.inventoryValueDraw();
   },
   watch: {
     inventoryvalue() {
       this.items = [];
       this.inventoryValueDraw();
     },
   },
   methods: {
     formatVal(value) {
       const val = (parseFloat(value) / 1).toFixed(2).replace('.', ',');
       return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '.');
     },
     inventoryValueDraw() {
       const totalValue = this.inventoryvalue;
       this.items = [{ name: 'Value', value: `${this.formatVal(totalValue)} EUR` }];
     },
   },
   components: {
     Box,
   },
 };
</script>
