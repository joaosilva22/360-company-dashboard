<template>
  <div class="container">
    <h1>All Sales</h1>
    <div class="table">
      <v-data-table
        v-bind:headers="headers"
        :items="items"
        hide-actions
      >
        <template slot="items" scope="props">
          <td>{{ props.item.customer }}</td>
          <td class="text-xs-right">{{ props.item.date }}</td>
          <td class="text-xs-right">{{ formatVal(props.item.net) }}</td>
        </template>
      </v-data-table>
    </div>
  </div>
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
     };
   },
   created() {
     this.salesInvoices().then((res) => {
       res.data.forEach((invoice) => {
         const customerId = invoice.CustomerID[0];
         const date = invoice.InvoiceDate[0];
         const net = invoice.DocumentTotals[0].NetTotal[0];
         this.customer(customerId).then((res1) => {
           const customer = res1.data.CompanyName[0];
           this.items.push({
             customer,
             date,
             net,
           });
         });
       });
     });
   },
   methods: {
     salesInvoices() {
       return Sales.salesInvoices();
     },
     customer(customerId) {
       return Sales.customer(customerId);
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
     border-bottom: none;
     overflow: scroll;
 }

 h1 {
     margin: 0;
     padding: 0;
     font-size: 3vw;
 }
</style>
