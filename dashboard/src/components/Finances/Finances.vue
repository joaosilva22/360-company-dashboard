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
        <accounts-payable v-bind:start="startSuppply" :end="endSuppply"></accounts-payable>
      </v-flex>

    </v-layout>
  </v-container>
</template>
<script>
import DatePicker from '@/components/DatePicker';
import AccountsPayable from '@/components/SupplyChain/AccountsPayable';

export default {
  data() {
    return {
      year: '0',
      startSuppply: '2015-01-01',
      endSuppply: '2015-12-12',
    };
  },
  components: {
    DatePicker,
    AccountsPayable,
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