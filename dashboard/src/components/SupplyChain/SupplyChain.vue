<template>
<v-container fluid grid-list-md>
    <v-layout row wrap>
      <v-flex xs12>
        <date-picker
        :start='startYear'
        :end='endYear'
        @year="updateYear"
        >
        </date-picker>
      </v-flex>
      

      <v-flex xs6 d-flex>
        <latest-purchases v-bind:purchasesinvoices="purchasesinvoices" ></latest-purchases>
      </v-flex>

      <v-flex xs6 d-flex>
      <purchases-to-date v-bind:purchasesinvoices="purchasesinvoices" ></purchases-to-date>
      </v-flex> 
     

      <v-flex xs6 d-flex>
         <top-supplier v-bind:suppliers="suppliers"></top-supplier>
      </v-flex>

      <v-flex xs6 d-flex>
        <inventory-composition v-bind:inventorycomposition="inventorycomposition"></inventory-composition>
      </v-flex>

      <v-flex xs6 d-flex>
        <accounts-payable v-bind:accountspayable="accountspayable"></accounts-payable>
      </v-flex>

      <v-flex xs6>
          <v-flex xs12 d-flex>
            <total-purchases v-bind:totalpurchases="totalpurchases"></total-purchases>
          </v-flex>
          <v-flex xs12 d-flex>
            <inventory-value v-bind:inventoryvalue="inventoryvalue"></inventory-value>
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
      year: this.startYear,
      startYear: '2015',
      endYear: '2017',
      startdate: '',
      enddate: '',
      accountspayable: [],
      inventorycomposition: [],
      inventoryvalue: [],
      purchasesinvoices: [],
      totalpurchases: [],
      suppliers: [],

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
      this.startdate = `${this.year}-01-01`;
      const nextyear = Number(this.year) + Number(1);
      this.enddate = `${nextyear}-01-01`;
      this.accountsPayable();
      this.getInventory();
      this.inventoryValue();
      this.purchasesInvoices();
      this.totalPurchases();
      this.topSuppliers();
    },
    async accountsPayable() {
      try {
        const response = await Purchases.accountsPayable(this.startdate, this.enddate);
        this.accountspayable = response.data;
        console.log(this.accountspayable);
      } catch (error) {
        this.error = error;
      }
    },
    async getInventory() {
      try {
        const response = await Inventory.getInventory();
        this.inventorycomposition = response.data;
      } catch (error) {
        this.error = error;
      }
    },
    async inventoryValue() {
      try {
        const response = await Supplier.inventoryValue();
        this.inventoryvalue = response.data;
        console.log(this.inventoryvalue);
      } catch (error) {
        this.error = error;
      }
    },
    async purchasesInvoices() {
      try {
        const response = await Purchases.purchasesInvoices(this.startdate, this.enddate);
        this.purchasesinvoices = response.data;
        console.log('------------');
        console.log(this.purchasesinvoices);
      } catch (error) {
        this.error = error;
      }
    },
    async totalPurchases() {
      try {
        const response = await Purchases.totalPurchases(this.startdate, this.enddate);
        this.totalpurchases = response.data;
        console.log('------------');
        console.log(this.totalpurchases);
      } catch (error) {
        this.error = error;
      }
    },
    async topSuppliers() {
      try {
        const response = await Supplier.topSuppliers(this.startdate, this.enddate);
        this.suppliers = response.data;
        console.log('------------');
        console.log(this.suppliers);
      } catch (error) {
        this.error = error;
      }
    },
  },
  computer: {
    endYear() {
      return this.$route.params.endYear;
    },
  },
  mounted: async function () {
    this.startdate = `${this.year}-01-01`;
    const nextyear = Number(this.year) + Number(1);
    this.enddate = `${nextyear}-01-01`;
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