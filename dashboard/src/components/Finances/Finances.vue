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

      <v-flex xs6 d-flex>
        <accounts-payable v-bind:items="payable"></accounts-payable>
      </v-flex>

      <v-flex xs6 d-flex>
        <accounts-receivable v-bind:items="receivable" ></accounts-receivable>
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

export default {
  data() {
    return {
      year: '',
      startdate: '2016-01-01',
      enddate: '2017-01-01',
      monthday: '-01-01',
      payable: [],
      receivable: [],
    };
  },
  components: {
    DatePicker,
    AccountsPayable,
    AccountsReceivable,
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
    async accountsReceivable() {
      try {
        const response = await Sales.accountsReceivable();
        this.receivable = response.data;
      } catch (error) {
        this.error = error;
      }
    },
  },
  mounted: async function () {
    await this.accountsPayable();
    await this.accountsReceivable();
  },
};
</script>
<style scoped>
</style>