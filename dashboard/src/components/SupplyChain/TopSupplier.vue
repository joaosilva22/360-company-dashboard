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
        { text: 'Net Value (EUR)', value: 'net' },
      ],
      max25chars: v => v.length <= 25 || 'Input too long!',
      tmp: '',
      items: [],
      search: '',
      pagination: {},
    };
  },
  props: ['suppliers'],
  created() {
    this.topSuppliers();
  },
  watch: {
    suppliers() {
      this.items = [];
      this.topSuppliers();
    },
  },
  methods: {
    formatVal(value) {
      const val = (parseFloat(value) / 1).toFixed(2).replace('.', ',');
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '.');
    },
    topSuppliers() {
      console.log(this.suppliers);
      this.suppliers.forEach((invoice) => {
        const net = invoice.TotalLiquido;
        const supplier = invoice.Nome;
        this.items.push({
          supplier,
          net,
        });
      });
    },
  },
};
</script>

<style scoped>
</style>
