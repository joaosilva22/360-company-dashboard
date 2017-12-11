<template>
  <v-card>
    <v-card-title>
      <h3 class="headline">Details Doc </h3>
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
        <td>{{ props.item.cod }}</td>
        <td class="text-xs-right">{{ props.item.quantity}}</td>
        <td class="text-xs-right">{{ props.item.unitPrice}}</td>
        <td class="text-xs-right">{{ formatVal(props.item.total)}}</td>
        
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
      items: [],
      headers: [
        {
          text: 'Article Code',
          align: 'left',
          sortable: false,
          value: 'cod',
        },
        { text: 'Quantity', value: 'quantity' },
        { text: 'Unit Price', value: 'unitPrice' },
        { text: 'Total (EUR)', value: 'total' },
      ],
      max25chars: v => v.length <= 25 || 'Input too long!',
      tmp: '',
      search: '',
      pagination: {},
      detailsDoc: [],

    };
  },
  props: ['doc'],
  created() {
    this.docDraw();
  },
  watch: {
    doc() {
      this.items = [];
      this.docDraw();
    },
  },
  methods: {
    formatVal(value) {
      const val = (parseFloat(value) / 1).toFixed(2).replace('.', ',');
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '.');
    },
    docDraw() {
      this.doc.forEach((invoice) => {
        const cod = invoice.CodArtigo;
        const quantity = invoice.Quantidade;
        const unitPrice = invoice.PrecoUnitario;
        const total = invoice.TotalLiquido;
        this.items.push({
          cod,
          quantity,
          unitPrice,
          total,
        });
      });
    },
    async detailsDocFunction(id) {
      try {
        const response = await ServiceDetailsDoc.details(id);
        this.detailsDoc = response.data;
      } catch (error) {
        this.error = error;
      }
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
