<template>
 <v-card>
    <v-card-title>
      <h3 class="headline">All Sales</h3>
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
        <router-link :to="'/Sale/' + props.item.year + '/' + encodeURIComponent(props.item.invoiceNo)" tag="tr">
          <td>{{ props.item.customer }}</td>
          <td class="text-xs-right">{{ props.item.date | formatDate }}</td>
          <td class="text-xs-right">{{ formatVal(props.item.net) }}</td>
        </router-link>
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
   props: ['year'],
   created() {
     this.salesInvoices(this.year).then((res) => {
       const invoices = res.data.Invoices;
       invoices.forEach((invoice) => {
         const date = invoice.InvoiceDate;
         const net = invoice.DocumentTotals.NetTotal;
         const customerId = invoice.CustomerID;
         this.customer(this.year, customerId).then((res1) => {
           const customer = res1.data.CompanyName;
           this.items.push({
             year: this.year,
             invoiceNo: invoice.InvoiceNo,
             customer,
             date,
             net,
           });
         });
       });
     });
   },
   methods: {
     salesInvoices(fiscalYear) {
       return Sales.salesInvoices(fiscalYear);
     },
     customer(fiscalYear, customerId) {
       return Sales.customer(fiscalYear, customerId);
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
