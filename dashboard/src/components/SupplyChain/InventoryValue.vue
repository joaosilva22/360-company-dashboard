<template>
  <box title="Inventory Value" :items="items"></box>
</template>

<script>
 import Supplier from '@/services/Supplier';
 import Box from '@/components/Box';

 export default {
   data() {
     return {
       items: [],
     };
   },
   props: ['year'],
   created() {
     this.inventoryValue().then((res) => {
       const totalValue = res.data;
       this.items = [{ name: 'Value', value: `${this.formatVal(totalValue)} EUR` }];
     });
   },
   methods: {
     inventoryValue() {
       return Supplier.inventoryValue();
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
