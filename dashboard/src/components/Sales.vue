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
      
      <v-flex xs12>
          <top-customers year="2016"></top-customers>
      </v-flex>
      <v-flex xs12>
        <latest-sales year="2016"></latest-sales>
      </v-flex>

      <v-flex >
        <average-sale-value year="2016"></average-sale-value>
      </v-flex>

	  <v-flex xs6>
        <sales-backlog></sales-backlog>
      </v-flex>
	  
      <v-flex xs3>
        <total-sales year="2016"></total-sales>
      </v-flex>

      <v-flex xs3>
        <average-sale-value year="2016"></average-sale-value>
      </v-flex>
      
      <v-flex xs6>
        <product-performance year="2016"></product-performance>
      </v-flex xs6>
    </v-layout>
  </v-container>
</template>




<script>
 import TotalSales from '@/components/TotalSales';
 import AverageSaleValue from '@/components/AverageSaleValue';
 import DatePicker from '@/components/DatePicker';
 import LatestSales from '@/components/LatestSales';
 import TopCustomers from '@/components/TopCustomers';
 import SalesBacklog from '@/components/SalesBacklog';
 import ProductPerformance from '@/components/ProductPerformance';
 
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
   },
   methods: {
     updateYear(value) {
       this.year = value;
     },
   },
 };
</script>

<style scoped>
</style>

