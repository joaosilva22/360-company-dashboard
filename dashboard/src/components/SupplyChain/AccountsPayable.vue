<template>
  <div class="container">
    <h1>Accounts Payable</h1>
    <div class="table">
      <v-data-table
        v-bind:headers="headers"
        :items="items"
        hide-actions
      >
        <template slot="items" scope="props">
          <td>{{ props.item.supplier }}</td>
          <td class="text-xs-right">{{ props.item.date }}</td>
          <td class="text-xs-right">{{ formatVal(props.item.net) }}</td>
        </template>
      </v-data-table>
    </div>
  </div>
</template>

<script>
 import Purchases from '@/services/Purchases';
 
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
       items: [],
     };
   },
   methods: {
     async accountsPayable(initialDate, endDate) {
       try {
         const response = Purchases.accountsPayable(initialDate, endDate);
         response.data.forEach((Doc) => {
           const supplier = Doc.NomeFornecedor[0];
           const date = Doc.DataDoc[0];
           const net = Doc.TotalDocumento[0];
           this.items.push({
             supplier,
             date,
             net,
           });
         });
       } catch (error) {
         this.error = error;
       }
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
