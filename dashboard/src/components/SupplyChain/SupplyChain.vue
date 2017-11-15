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

      <v-flex xs8>
         <top-supplier></top-supplier>
      </v-flex>

      <v-flex s4>
        <inventory-value></inventory-value>
        <total-purchases></total-purchases>
      </v-flex>

      <v-flex xs8>
        <accounts-payable></accounts-payable>
      </v-flex>

      <v-flex xs4>
        
      </v-flex>

      <v-flex xs8>
        <latest-purchases></latest-purchases>
      </v-flex>

    </v-layout>
  </v-container>
</div>
</template>


<script>
import DatePicker from '@/components/DatePicker';
import LatestPurchases from '@/components/SupplyChain/LatestPurchases';
import TopSupplier from '@/components/SupplyChain/TopSupplier';
import AccountsPayable from '@/components/SupplyChain/AccountsPayable';
import InventoryValue from '@/components/SupplyChain/InventoryValue';
import TotalPurchases from '@/components/SupplyChain/TotalPurchases';

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
    DatePicker,
    LatestPurchases,
    TopSupplier,
    AccountsPayable,
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

