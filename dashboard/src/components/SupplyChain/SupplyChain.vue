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
        <latest-purchases v-bind:items="purchasesinvoices" ></latest-purchases>
      </v-flex>

      <v-flex xs6 d-flex>
      <purchases-to-date v-bind:items="purchasesinvoices" ></purchases-to-date>
      </v-flex>

      <v-flex xs6 d-flex>
         <top-supplier v-bind:items="topsupplier"></top-supplier>
      </v-flex>

      <v-flex xs6 d-flex>
        <inventory-composition v-bind:items="inventory"></inventory-composition>
      </v-flex>

      <v-flex xs6 d-flex>
        <accounts-payable v-bind:items="payable"></accounts-payable>
      </v-flex>

      <v-flex xs6>
          <v-flex xs12 d-flex>
            <total-purchases v-bind:items="totalpurchases"></total-purchases>
          </v-flex>
          <v-flex xs12 d-flex>
            <inventory-value v-bind:items="inventoryvalue"></inventory-value>
          </v-flex>
      </v-flex>

    </v-layout>
  </v-container>
</template>


<script>
import DatePicker from '@/components/DatePicker';
import AccountsPayable from '@/components/SupplyChain/AccountsPayable';
import InventoryComposition from '@/components/SupplyChain/InventoryComposition';
import InventoryValue from '@/components/SupplyChain/InventoryValue';
import LatestPurchases from '@/components/SupplyChain/LatestPurchases';
import PurchasesToDate from '@/components/SupplyChain/PurchasesToDate';
import TopSupplier from '@/components/SupplyChain/TopSupplier';
import TotalPurchases from '@/components/SupplyChain/TotalPurchases';

import Supplier from '@/services/Supplier';
import Inventory from '@/services/Inventory';
import Purchases from '@/services/Purchases';

export default {
  data() {
    return {
      year: '',
      startdate: '2016-01-01',
      enddate: '2017-01-01',
      monthday: '-01-01',
      payable: [],
      inventory: [],
      inventoryalue: [],
      purchasesinvoices: [],
      totalpurchases: [],
      topsupplier: [],

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
      this.startdate = this.year + this.monthday;
      this.nextyear = Number(this.year) + Number(1);
      this.enddate = this.nextyear + this.monthday;
    },
    async accountsPayable() {
      try {
        const response = await Purchases.accountsPayable(this.startdate, this.enddate);
        this.payable = response.data;
      } catch (error) {
        this.error = error;
      }
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
    async purchasesInvoices() {
      try {
        const response = await Purchases.purchasesInvoices(this.startdate, this.enddate);
        this.purchasesinvoices = response.data;
      } catch (error) {
        this.error = error;
      }
    },
    async totalPurchases() {
      try {
        const response = await Purchases.totalPurchases(this.startdate, this.enddate);
        this.totalpurchases = response.data;
      } catch (error) {
        this.error = error;
      }
    },
    async topSuppliers() {
      try {
        const response = await Supplier.topSuppliers(this.startdate, this.enddate);
        this.topsupplier = response.data;
      } catch (error) {
        this.error = error;
      }
    },
  },
  mounted: async function () {
    await this.accountsPayable();
    await this.getInventory();
    await this.inventoryValue();
    await this.purchasesInvoices();
    await this.totalPurchases();
    await this.topSuppliers();
  },
};
</script>

<style scoped>
</style>