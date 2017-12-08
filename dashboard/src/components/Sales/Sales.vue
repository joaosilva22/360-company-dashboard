<template>
   <v-container fluid grid-list-md>
    <v-layout row wrap>
      <v-flex xs12>
        <date-picker
        start="2016"
        end="2016"
        @year="updateYear"
        >
        </date-picker>
      </v-flex>
      
      <v-flex xs6 d-flex>
        <sales-to-date year="2016"></sales-to-date>
      </v-flex>
      
      <v-flex xs6 d-flex>
        <product-performance year="2016"></product-performance>
      </v-flex>
      
      <v-flex xs6 d-flex>
        <total-sales year="2016"></total-sales>
      </v-flex>

      <v-flex xs6 d-flex>
        <average-sale-value year="2016"></average-sale-value>
      </v-flex>
      
      <v-flex xs5>
          <top-customers year="2016"></top-customers>
      </v-flex>
      
      <v-flex xs7>
        <latest-sales year="2016"></latest-sales>
      </v-flex>

	  <v-flex xs12>
        <sales-backlog></sales-backlog>
      </v-flex>
      
    </v-layout>
  </v-container>
</template>




<script>
 import TotalSales from '@/components/Sales/TotalSales';
 import AverageSaleValue from '@/components/Sales/AverageSaleValue';
 import DatePicker from '@/components/DatePicker';
 import LatestSales from '@/components/Sales/LatestSales';
 import TopCustomers from '@/components/Sales/TopCustomers';
 import SalesBacklog from '@/components/Sales/SalesBacklog';
 import ProductPerformance from '@/components/Sales/ProductPerformance';
 import SalesToDate from '@/components/Sales/SalesToDate';
 
 export default {
   data() {
     return {
       year: 0,
     };
   },
   components: {
     TotalSales,
     AverageSaleValue,
     DatePicker,
     LatestSales,
     TopCustomers,
     SalesBacklog,
     ProductPerformance,
     SalesToDate,
   },
   methods: {
     updateYear(value) {
       this.year = value;
     },
   },
   /*
       async accountsReceivable() {
      this.receivable = await Sales.accountsReceivable();
    },
    */
 };
</script>

<style scoped>
</style>

