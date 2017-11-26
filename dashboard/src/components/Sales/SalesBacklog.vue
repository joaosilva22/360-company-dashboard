<template>
 <v-card>
    <v-card-title>
      <h3 class="headline">Sales Backlog</h3>
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
        <td>{{ props.item.customer }}</td>
		<td class="text-xs-right">{{ props.item.date | formatDate }}</td>
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
 import Sales from '@/services/Sales';
 
 export default {
   data() {
     return {
       headers: [
         {
           text: 'Customer',
           align: 'left',
           sortable: false,
           value: 'customerName',
         },
         { text: 'Date', value: 'date' },
         { text: 'Net Total (EUR)', value: 'net' },
       ],
       items: [],
       max25chars: v => v.length <= 25 || 'Input too long!',
       tmp: '',
       search: '',
       pagination: {},
     };
   },
   created() {
     this.salesBacklog().then((res) => {
       const backlog = res.data;
       backlog.forEach((sale) => {
         const customer = sale.Entidade;
         const date = sale.Data;
         const net = sale.TotalMerc;
         this.items.push({
           customer,
           date,
           net,
         });
       });
     });
   },
   methods: {
     salesBacklog() {
       return Sales.salesBacklog();
     },
     formatVal(value) {
       const val = (parseFloat(value) / 1).toFixed(2).replace('.', ',');
       return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '.');
     },
   },
 };
</script>

<style scoped>
</style>