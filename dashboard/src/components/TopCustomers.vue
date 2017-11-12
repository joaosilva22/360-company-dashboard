<template>
  <div class="container">
    <h1>All Customers</h1>
    <div class="table">
      <v-data-table
        v-bind:headers="headers"
        :items="items"
        hide-actions
      >
        <template slot="items" scope="props">
          <td>{{ props.item.customerName }}</td>
          <td class="text-xs-right">{{ formatVal(props.item.netValue) }}</td>
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
           value: 'customerName',
         },
         { text: 'Net Value (EUR)', value: 'netValue' },
       ],
       items: [],
     };
   },
   created() {
     this.customers().then((res) => {
       const customers = res.data.customers;
       customers.forEach((customer) => {
         const customerId = customer.CustomerID[0];
         const customerName = customer.CompanyName[0];
         this.customerNetValue(customerId).then((res1) => {
           const netValue = res1.data.netValue;
           this.items.push({
             customerName,
             netValue,
           });
         });
       });
     });
   },
   methods: {
     customers() {
       return Sales.customers();
     },
     customerNetValue(customerId) {
       return Sales.customerNetValue(customerId);
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
