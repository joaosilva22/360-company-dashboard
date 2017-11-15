<template>
  <grid rows="7" cols="12">
     <grid-item row="1" height="1" col="1" width="12">
       <date-picker
        start="2016"
        end="2016"
        @year="updateYear"
        >
       </date-picker>
     </grid-item>
     <grid-item row="2" height="3" col="1" width="9">
        <latest-sales year="2016"></latest-sales>
     </grid-item>
    <grid-item row="2" height="1" col="10" width="3">
       <total-sales year="2016"></total-sales>
     </grid-item>
     <grid-item row="3" height="1" col="10" width="3">
       <average-sale-value year="2016"></average-sale-value>
     </grid-item>
     <grid-item row="5" height="3" col="1" width="9">
       <top-customers year="2016"></top-customers>
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
      year: 0,
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
    updateYear(value) {
      this.year = value;
    },
  },
};
</script>

<style scoped>
</style>

