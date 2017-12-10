<template>
  <v-card>
    <v-card-title>
      <h3 class="headline">Accounts Receivable</h3>
      <v-spacer></v-spacer>
      <v-text-field
        append-icon="search"
        label="Search"
        single-line
        hide-details
        v-model="search"
      ></v-text-field>
    </v-card-title>
    <v-data-table
        v-bind:headers="headers"
        v-bind:items="items"
        v-bind:search="search"
      >
      <template slot="items" slot-scope="props"> <!-- TODO change ?? -->
        <td>{{props.item.customer }}</td>
        <td class="text-xs-right">{{props.item.date | formatDate}}</td>
        <td class="text-xs-right">{{ formatVal(props.item.net) }}</td>
        </td>
      </template>
      <template slot="pageText" slot-scope="{ pageStart, pageStop }">
        From {{ pageStart }} to {{ pageStop }}
      </template>
    </v-data-table>
  </v-card>
</template>

<script>
export default {
  data() {
    return {
      headers: [
        {
          text: 'Customer',
          align: 'left',
          sortable: false,
          value: 'customer',
        },
        { text: 'Date', value: 'date' },
        { text: 'Net Value (EUR)', value: 'net' },
      ],
      items: [],
      max25chars: v => v.length <= 25 || 'Input too long!',
      tmp: '',
      search: '',
      pagination: {},
    };
  },
  props: ['receivable'],
  watch: {
    receivable() {
      this.items = [];
      this.accountsReceivable();
    },
  },
  created() {
    this.accountsReceivable();
  },
  methods: {
    formatVal(value) {
      const val = (parseFloat(value) / 1).toFixed(2).replace('.', ',');
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '.');
    },
    accountsReceivable() {
      const invoices = this.receivable;
      invoices.forEach((invoice) => {
        const net = invoice.TotalMerc;
        const date = invoice.Data;
        const customer = invoice.Entidade;
        this.items.push({
          customer,
          date,
          net,
        });
      });
    },
  },
};
</script>

<style scoped>
 .container {
     max-width: 100%;
     max-height: 100%;
     height: 100%;
     margin: 0;
     padding: 0;
     border-bottom: 1px solid black;
     overflow: hidden;
     display: table;
 }

 .table {
     max-height: 100%;
     border: 1px solid black;
     border-bottom: none;
     overflow: scroll;
 }

 h1 {
     margin: 0;
     padding: 0;
     font-size: 3vw;
 }
</style>
