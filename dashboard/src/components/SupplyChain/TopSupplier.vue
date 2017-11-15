<template>
  <v-card>
    <v-card-title>
      <h3 class="headline">All Suppliers</h3>
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
      <template slot="items" slot-scope="props">
        <td>{{ props.item.supplier }}</td>
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
import Supplier from '@/services/Supplier';

export default {
  data() {
    return {
      headers: [
        {
          text: 'Supplier',
          align: 'left',
          sortable: false,
          value: 'supplier',
        },
        { text: 'Net Value (EUR)', value: 'net' },
      ],
      items: [],
      max25chars: v => v.length <= 25 || 'Input too long!',
      tmp: '',
      search: '',
      pagination: {},
    };
  },
  props: ['year'],
  created() {
    this.topSuppliers().then((res) => {
      const invoices = res.data;
      invoices.forEach((invoice) => {
        const net = invoice.TotalMerc;
        const supplier = invoice.NomeFornecedor;
        this.items.push({
          supplier,
          net,
        });
      });
    });
  },
  methods: {
    topSuppliers() {
      return Supplier.topSuppliers();
    },
    formatVal(value) {
      const val = (parseFloat(value) / 1).toFixed(2).replace('.', ',');
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '.');
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
     overflow: scroll;
 }

 h1 {
     margin: 0;
     padding: 0;
     font-size: 3vw;
 }
</style>
