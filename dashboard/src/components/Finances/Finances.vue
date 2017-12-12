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
        <accounts-payable v-bind:accountspayable="accountspayable"></accounts-payable>
      </v-flex>

      <v-flex xs6 d-flex>
        <accounts-receivable v-bind:receivable="receivable" ></accounts-receivable>
      </v-flex>

      <v-flex xs6 d-flex>
        <current-ratio v-bind:year="2016" ></current-ratio>
      </v-flex>

    </v-layout>
  </v-container>
</template>
<script>
import DatePicker from '@/components/DatePicker';
import AccountsPayable from '@/components/SupplyChain/AccountsPayable';
import AccountsReceivable from '@/components/Sales/AccountsReceivable';
import Purchases from '@/services/Purchases';
import Sales from '@/services/Sales';
import Account from '@/services/Account';
import CurrentRatio from '@/components/Finances/CurrentRatio';

export default {
  data() {
    return {
      year: this.startYear,
      startYear: '2015',
      endYear: '2017',
      startdate: '',
      enddate: '',
      accountspayable: [],
      receivable: [],
      currentratio: [],
    };
  },
  components: {
    DatePicker,
    AccountsPayable,
    AccountsReceivable,
    CurrentRatio,
  },
  methods: {
    updateYear(value) {
      this.year = value;
      this.startdate = `${this.year}-01-01`;
      const nextyear = Number(this.year) + Number(1);
      this.enddate = `${nextyear}-01-01`;
      this.accountsPayable();
      this.accountsReceivable();
    },
    async accountsPayable() {
      try {
        const response = await Purchases.accountsPayable(this.startdate, this.enddate);
        this.accountspayable = response.data;
      } catch (error) {
        this.error = error;
      }
    },
    async accountsReceivable() {
      try {
        const response = await Sales.accountsReceivable();
        this.receivable = response.data;
      } catch (error) {
        this.error = error;
      }
    },
    async currentRatio() {
      try {
        const response = await Account.currentRatio(this.year);
        this.currentratio = response.data;
        console.log(this.currentratio);
      } catch (error) {
        this.error = error;
      }
    },
  },
  mounted: async function () {
    this.startdate = `${this.year}-01-01`;
    const nextyear = Number(this.year) + Number(1);
    this.enddate = `${nextyear}-01-01`;
    await this.accountsPayable();
    await this.accountsReceivable();
    await this.currentRatio();
  },
};
</script>
<style scoped>
</style>