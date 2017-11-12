<template>
  <grid rows="12" cols="12">
    <grid-item row="1" height="1" col="1" width="12">
      <date-picker
        start-year="2016"
        start-month="6"
        end-year="2020"
        end-month="6"
        @fromYear="updateFromYear"
        @fromMonth="updateFromMonth"
        @toYear="updateToYear"
        @toMonth="updateToMonth"
      >
      </date-picker>
    </grid-item>
    <grid-item row="2" height="2" col="1" width="3">
      <total-sales></total-sales>
    </grid-item>
    <grid-item row="2" height="3" col="4" width="3">
      <average-sale-value></average-sale-value>
    </grid-item>
    <grid-item row="2" height="5" col="9" width="4">
      <average-sale-value></average-sale-value>
    </grid-item>

    <grid-item row="7" height="6" col="1" width="4">
      <latest-sales></latest-sales>
    </grid-item>

    <grid-item row="7" height="6" col="5" width="4">
      <top-customers></top-customers>
    </grid-item>
  </grid>
</template>

<script>
 import Grid from '@/components/Grid';
 import GridItem from '@/components/GridItem';
 import TotalSales from '@/components/TotalSales';
 import AverageSaleValue from '@/components/AverageSaleValue';
 import DatePicker from '@/components/DatePicker';
 import LatestSales from '@/components/LatestSales';
 import TopCustomers from '@/components/TopCustomers';
 
 export default {
   data() {
     return {
       fromYear: 0,
       fromMonth: 0,
       toYear: 0,
       toMonth: 0,
     };
   },
   components: {
     Grid,
     GridItem,
     TotalSales,
     AverageSaleValue,
     DatePicker,
     LatestSales,
     TopCustomers,
   },
   methods: {
     updateFromYear(value) {
       this.fromYear = value;
     },
     updateFromMonth(value) {
       this.fromMonth = value;
     },
     updateToYear(value) {
       this.toYear = value;
     },
     updateToMonth(value) {
       this.toMonth = value;
     },
   },
 };
</script>

<style scoped>
</style>

