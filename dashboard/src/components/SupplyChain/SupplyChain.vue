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
        <latest-purchases v-bind:start="startDate" :end="endDate" ></latest-purchases>
      </v-flex>

      <v-flex xs6 d-flex>
      <purchases-to-date v-bind:start="startDate" :end="endDate"></purchases-to-date>
      </v-flex>

      <v-flex xs6 d-flex>
         <top-supplier v-bind:start="startDate" :end="endDate"></top-supplier>
      </v-flex>

      <v-flex xs6 d-flex>
        <inventory-composition></inventory-composition>
      </v-flex>

      <v-flex xs6 d-flex>
        <accounts-payable v-bind:start="startDate" :end="endDate"></accounts-payable>
      </v-flex>

      <v-flex xs6>
          <v-flex xs12 d-flex>
            <total-purchases v-bind:start="startDate" :end="endDate"></total-purchases>
          </v-flex>
          <v-flex xs12 d-flex>
            <inventory-value></inventory-value>
          </v-flex>
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
      year: '',
      startDate: '',
      endDate: '',
      monthDay: '-01-01',
      nextyear: '',
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