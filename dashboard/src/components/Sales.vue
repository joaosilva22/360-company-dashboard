<template>
  <grid rows="12" cols="12">
    <grid-item row="1" height="4" col="1" width="4">
      <total-sales></total-sales>
    </grid-item>
    <grid-item row="1" height="2" col="5" width="4">
      <average-sale-value></average-sale-value>
    </grid-item>
    <grid-item row="1" height="2" col="9" width="4">
      <average-sale-value></average-sale-value>
    </grid-item>
  </grid>
</template>

<script>
 import Grid from '@/components/Grid';
 import GridItem from '@/components/GridItem';
 import TotalSales from '@/components/TotalSales';
 import AverageSaleValue from '@/components/AverageSaleValue';

 export default {
   components: {
     Grid,
     GridItem,
     TotalSales,
     AverageSaleValue,
   },
 };
</script>

<style scoped>
</style>

