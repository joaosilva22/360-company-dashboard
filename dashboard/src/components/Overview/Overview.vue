<template>
   <v-container fluid grid-list-md>
    <v-layout row wrap>
      <v-flex xs12>
        <date-picker
        start="2014"
        end="2017"
        @year="updateYear"
        >
        </date-picker>
      </v-flex>
      
      <v-flex xs6>
        <inventory-composition v-bind:items="inventory" ></inventory-composition>
      </v-flex>
      
      <v-flex xs6 d-flex>
        <product-performance year="2016"></product-performance>
      </v-flex>
      
      <v-flex xs6 d-flex>
        <inventory-value v-bind:items="inventoryvalue" ></inventory-value>
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
import Inventory from '@/services/Inventory';
import Supplier from '@/services/Supplier';

export default {
  data() {
    return {
      year: '',
      startDate: '',
      endDate: '',
      monthDay: '-01-01',
      nextyear: '',
      inventory: [],
      inventoryvalue: [],
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
      this.startdate = this.year + this.monthday;
      this.nextyear = Number(this.year) + Number(1);
      this.enddate = this.nextyear + this.monthday;
    },
    async getInventory() {
      try {
        const response = await Inventory.getInventory();
        this.inventory = response.data;
      } catch (error) {
        this.error = error;
      }
    },
    async inventoryValue() {
      try {
        const response = await Supplier.inventoryValue();
        this.inventoryvalue = response.data;
      } catch (error) {
        this.error = error;
      }
    },
  },
  mounted: async function () {
    await this.getInventory();
    await this.inventoryValue();
  },
};
</script>

<style scoped>
</style>