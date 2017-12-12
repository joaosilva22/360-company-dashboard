<template>
   <v-container fluid grid-list-md>
    <v-layout row wrap>
      <v-flex xs12>
        <v-card>
          <v-card-title primary-title>
            <div>
              <h3 class="headline">Details</h3>
              <router-link :to="'/Customer/' + $route.params.year + '/' + invoice.CustomerID" tag="p">CustomerID: {{ invoice.CustomerID }}</router-link>
              <p>DocumentStatus: {{ invoice.DocumentStatus }}</p>
              <p>DocumentTotals: {{ invoice.DocumentTotals }}</p>
              <p>InvoiceDate: {{ invoice.InvoiceDate }}</p>
              <p>InvoiceNo: {{ invoice.InvoiceNo }}</p>
              <p>InvoiceType: {{ invoice.InvoiceType }}</p>
              <p>MovementStartTime: {{ invoice.MovementStartTime }}</p>
              <p>SystemEntryDate: {{ invoice.SystemEntryDate }}</p>
              <p>WithholdingTax: {{ invoice.WithholdingTax }}</p>
            </div>
          </v-card-title>
        </v-card>
      </v-flex>
      
      <v-flex xs12>
      <v-card>
        <v-card-title>
          <h3 class="headline">Invoice Lines</h3>
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
          v-bind:items="invoice.Lines"
          v-bind:search="search"
        >
        <template slot="items" slot-scope="props">
          <td>{{ props.item.LineNumber }}</td>
          <td>{{ props.item.ProductCode }}</td>
          <td>{{ props.item.ProductDescription }}</td>
          <td class="text-xs-right">{{ props.item.Quantity }}</td>
          <td class="text-xs-right">{{ props.item.UnitPrice }}</td>
          <td>{{ props.item.Description }}</td>
          <td class="text-xs-right">{{ props.item.CreditAmount }}</td>
        </template>
      </v-data-table>
    </v-card>
    </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
 import Sales from '@/services/Sales';

 export default {
   data() {
     return {
       headers: [
         {
           text: 'LineNumber',
           align: 'left',
           value: '"LineNumber',
         },
         { text: 'ProductCode', align: 'left', value: 'ProductCode' },
         { text: 'ProductDescription', align: 'left', value: 'ProductDescription' },
         { text: 'Quantity', value: 'Quantity' },
         { text: 'UnitPrice', value: 'UnitPrice' },
         { text: 'Description', align: 'left', value: 'Description' },
         { text: 'CreditAmount', value: 'CreditAmount' },
       ],
       invoice: {},
       search: '',
     };
   },
   created() {
     this.getInvoice().then((res) => {
       this.invoice = res.data;
       console.log(this.invoice);
     });
   },
   methods: {
     getInvoice() {
       return Sales.invoice(this.$route.params.year, this.$route.params.invoiceNo);
     },
   },
 };
</script>

<style scoped>
</style>