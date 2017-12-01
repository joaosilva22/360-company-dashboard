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
        <accounts-payable v-bind:start="startDate" :end="endDate"></accounts-payable>
      </v-flex>
      <v-flex xs6 d-flex>
        <accounts-receivable></accounts-receivable>
      </v-flex>

    </v-layout>
  </v-container>
</template>
<script>
import DatePicker from '@/components/DatePicker';
import AccountsPayable from '@/components/SupplyChain/AccountsPayable';
import AccountsReceivable from '@/components/SupplyChain/AccountsReceivable';

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
    AccountsPayable,
    AccountsReceivable,
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