<template>
 <v-card>
    <v-card-title>
      <h3 class="headline">All Customers</h3>
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
        <router-link to="/" tag="tr">                                                                                               
            <td>{{ props.item.customer }}</td>
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
           value: 'customerName',
         },
         { text: 'Net Total (EUR)', value: 'net' },
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
     this.customers(this.year).then((res) => {
       const customers = res.data;
       customers.forEach((instance) => {
         const customer = instance.CompanyName;
         const customerId = instance.CustomerID;
         this.customerNetTotal(this.year, customerId).then((res1) => {
           const net = res1.data;
           this.items.push({
             customer,
             net,
           });
         });
       });
     });
   },
   methods: {
     customers(fiscalYear) {
       return Sales.customers(fiscalYear);
     },
     customerNetTotal(fiscalYear, customerId) {
       return Sales.customerNetTotal(fiscalYear, customerId);
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
