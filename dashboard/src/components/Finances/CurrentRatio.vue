<template>
  <box title="Current Ratio" :items="items"></box>
</template>

<script>
 import Box from '@/components/Box';

 export default {
   props: ['currentratio'],
   data() {
     return {
       items: [],
     };
   },
   created() {
     this.currentRatioDraw();
   },
   watch: {
     currentratio() {
       this.items = [];
       this.currentRatioDraw();
     },
   },
   methods: {
     formatVal(value) {
       const val = (parseFloat(value) / 1).toFixed(2).replace('.', ',');
       return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '.');
     },
     currentRatioDraw() {
       const totalValue = this.currentratio;
       this.items = [{ name: 'Value', value: `${this.formatVal(totalValue)} EUR` }];
     },
   },
   components: {
     Box,
   },
 };
</script>
