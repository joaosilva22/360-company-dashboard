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

      <v-flex xs7>
         <top-supplier></top-supplier>
      </v-flex>

      <v-flex xs7>
        <accounts-payable></accounts-payable>
      </v-flex>

      <v-flex xs7>
        <latest-purchases></latest-purchases>
      </v-flex>

    </v-layout>
  </v-container>
</template>


<script>
import DatePicker from '@/components/DatePicker';
import LatestPurchases from '@/components/SupplyChain/LatestPurchases';
import TopSupplier from '@/components/SupplyChain/TopSupplier';
import AccountsPayable from '@/components/SupplyChain/AccountsPayable';

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
  },
  methods: {
    updateYear(value) {
      this.year = value;
    },
  },
};
</script>

