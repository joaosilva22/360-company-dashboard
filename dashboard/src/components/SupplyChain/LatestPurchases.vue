<template>
 <v-card>
    <v-card-title>
      <h3 class="headline">All Purchases</h3>
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
        <td class="text-xs-right">{{ props.item.date | formatDate }}</td>
        <td class="text-xs-right">{{ formatVal(props.item.net * -1) }}</td>
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
          text: 'Supplier',
          align: 'left',
          sortable: false,
          value: 'supplier',
        },
        { text: 'Date', value: 'date' },
        { text: 'Net Value (EUR)', value: 'net' },
      ],
      max25chars: v => v.length <= 25 || 'Input too long!',
      tmp: '',
      search: '',
      pagination: {},
      items: [],
    };
  },
  props: ['purchasesinvoices'],
  created() {
    this.purchasesInvoicesDraw();
  },
  watch: {
    purchasesinvoices() {
      this.items = [];
      this.purchasesInvoicesDraw();
    },
  },
  methods: {
    formatVal(value) {
      const val = (parseFloat(value) / 1).toFixed(2).replace('.', ',');
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '.');
    },
    purchasesInvoicesDraw() {
      console.log(this.purchasesinvoices);
      this.purchasesinvoices.forEach((invoice) => {
        const date = invoice.DataDoc;
        const net = invoice.TotalLiquido;
        const supplier = invoice.NomeFornecedor;
        this.items.push({
          supplier,
          date,
          net,
        });
      });
    },
  },
};
</script>

<style scoped>
</style>
