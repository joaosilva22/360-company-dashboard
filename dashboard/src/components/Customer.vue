<template>
   <v-container fluid grid-list-md>
    <v-layout row wrap>
      <v-flex xs12>
        <v-card>
          <v-card-title primary-title>
            <div>
              <h3 class="headline">Customer</h3>
              <p>ID: {{ customer.Id }}</p>
              <p>AccountID: {{ customer.AccountID }}</p>
              <p>BillingAddress: {{ customer.BillingAddress }}</p>
              <p>CompanyName: {{ customer.CompanyName }}</p>
              <p>CustomerID: {{ customer.CustomerID }}</p>
              <p>CustomerTaxID: {{ customer.CustomerTaxID }}</p>
              <p>SelfBillingIndicator: {{ customer.SelfBillingIndicator }}</p>
              <p>ShipToAddress: {{ customer.ShipToAddress }}</p>
            </div>
          </v-card-title>
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
       customer: {},
     };
   },
   created() {
     this.getCustomer().then((res) => {
       this.customer = res.data;
       console.log(this.customer);
     });
   },
   methods: {
     getCustomer() {
       return Sales.customer(this.$route.params.year, this.$route.params.id);
     },
   },
 };
</script>

<style scoped>
</style>