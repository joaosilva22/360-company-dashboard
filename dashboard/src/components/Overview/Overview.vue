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
      
      <v-flex xs6>
        <inventory-composition></inventory-composition>
      </v-flex>
      
      <v-flex xs6 d-flex>
        <product-performance year="2016"></product-performance>
      </v-flex>
      
      <v-flex xs6 d-flex>
        <inventory-value></inventory-value>
      </v-flex>

      <v-flex xs6 d-flex>
        <total-sales year="2016"></total-sales>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import DatePicker from '@/components/DatePicker';
import InventoryValue from '@/components/SupplyChain/InventoryValue';
import InventoryComposition from '@/components/SupplyChain/InventoryComposition';
import ProductPerformance from '@/components/Sales/ProductPerformance';
import TotalSales from '@/components/Sales/TotalSales';

export default {
  data() {
    return {
      year: '',
      startDate: '',
      endDate: '',
      monthDay: '-01-01',
      nextyear: '',
    };
  },
  components: {
    DatePicker,
    InventoryValue,
    InventoryComposition,
    ProductPerformance,
    TotalSales,
  },
  methods: {
    updateYear(value) {
      this.year = value;
      this.startDate = this.year + this.monthDay;
      this.nextyear = Number(this.year) + Number(1);
      this.endDate = this.nextyear + this.monthDay;
    },
  },
  amonted: {
    startDate: this.year + this.monthDay,
    nextyear: Number(this.year) + Number(1),
    endDate: this.nextyear + this.monthDay,

  },
};
</script>

<style scoped>
</style>