<template>
  <box title="Current Ratio" :items="items"></box>
</template>

<script>
 import Account from '@/services/Account';
 import Box from '@/components/Box';

 export default {
   data() {
     return {
       items: [],
     };
   },
   props: ['year'],
   created() {
     this.currentRatio(this.year).then((res) => {
       console.log(this.formatVal(res.data));
       this.items = [{ name: 'Value', value: `${this.formatVal(res.data)} EUR` }];
     });
   },
   methods: {
     currentRatio(fiscalYear) {
       return Account.currentRatio(fiscalYear);
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
