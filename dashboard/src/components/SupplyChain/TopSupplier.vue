<template>
  <div class="container">
    <h1>All Supplier</h1>
    <div class="table">
      <v-data-table
        v-bind:headers="headers"
        :items="items"
        hide-actions
      >
        <template slot="items" scope="props">
          <td>{{ props.item.supplierName }}</td>
          <td class="text-xs-right">{{ formatVal(props.item.netValue) }}</td>
        </template>
      </v-data-table>
    </div>
  </div>
</template>

<script>
 // import Purchases from '@/services/Purchases';
 
 export default {
   data() {
     return {
       headers: [
         {
           text: 'Supplier',
           align: 'left',
           sortable: false,
           value: 'supplierName',
         },
         { text: 'Net Value (EUR)', value: 'netValue' },
       ],
       items: [],
     };
   },  /*
   created() {
    this.supplier().then((res) => {
       const suppliers = res.data.supplier;
       suppliers.forEach((supplier) => {
         const customerId = customer.CustomerID[0];
         const customerName = customer.CompanyName[0];
         this.customerNetValue(customerId).then((res1) => {
           const netValue = res1.data.netValue;
           this.items.push({
             supplierName,
             netValue,
           });
         });
       });
     });
   }, */
   methods: {
       /*
     suppliers() {
       return Purchases.suppliers();
     },
     suppliweNetValue(supplierId) {
       return Purchases.supplierNetValue(supplierId);
     },
    */
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
