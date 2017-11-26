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
        <purchases-to-date></purchases-to-date>
      </v-flex>
      
      <v-flex xs6 d-flex>
        <latest-purchases></latest-purchases>
      </v-flex>
      
      <v-flex xs6 d-flex>
        <inventory-value></inventory-value>
      </v-flex>
      
      <v-flex xs6 d-flex>
        <total-purchases></total-purchases>
      </v-flex>
      
      <v-flex xs5 d-flex>
         <top-supplier></top-supplier>
      </v-flex>
     
      <v-flex xs7 d-flex>
        <accounts-payable></accounts-payable>
      </v-flex>

      <v-flex xs5 d-flex>
        <inventory-composition></inventory-composition>
      </v-flex>

    </v-layout>
  </v-container>
</template>


<script>
import DatePicker from '@/components/DatePicker';
import LatestPurchases from '@/components/SupplyChain/LatestPurchases';
import TopSupplier from '@/components/SupplyChain/TopSupplier';
import AccountsPayable from '@/components/SupplyChain/AccountsPayable';
import InventoryValue from '@/components/SupplyChain/InventoryValue';
import TotalPurchases from '@/components/SupplyChain/TotalPurchases';
import PurchasesToDate from '@/components/SupplyChain/PurchasesToDate';
import InventoryComposition from '@/components/SupplyChain/InventoryComposition';


export default {
  data() {
    return {
      year: '0',
    };
  },
  components: {
    DatePicker,
    LatestPurchases,
    TopSupplier,
    AccountsPayable,
    InventoryValue,
    TotalPurchases,
    PurchasesToDate,
    InventoryComposition,
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