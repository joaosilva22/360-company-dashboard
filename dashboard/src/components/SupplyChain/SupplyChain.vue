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
         <top-supplier></top-supplier>
      </v-flex>
     
      <!--<v-flex xs12>
        <accounts-payable></accounts-payable>
      </v-flex> -->

      <v-flex xs12>
        <latest-purchases></latest-purchases>
      </v-flex>
 <v-flex d-flex>
        <inventory-value></inventory-value>
      </v-flex>
      
      <v-flex d-flex>
        <total-purchases></total-purchases>
      </v-flex>
      

    </v-layout>
  </v-container>
</template>


<script>
import Grid from '@/components/Grid';
import GridItem from '@/components/GridItem';
import DatePicker from '@/components/DatePicker';
import LatestPurchases from '@/components/SupplyChain/LatestPurchases';
import TopSupplier from '@/components/SupplyChain/TopSupplier';
// import AccountsPayable from '@/components/SupplyChain/AccountsPayable';
import InventoryValue from '@/components/SupplyChain/InventoryValue';
import TotalPurchases from '@/components/SupplyChain/TotalPurchases';

export default {
  data() {
    return {
      year: '0',
    };
  },
  components: {
    Grid,
    GridItem,
    DatePicker,
    LatestPurchases,
    TopSupplier,
   //  AccountsPayable,
    InventoryValue,
    TotalPurchases,
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