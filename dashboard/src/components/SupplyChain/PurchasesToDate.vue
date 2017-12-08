<template>
  <v-card>
    <v-card-title>
      <h3 class="headline mb-0">Purchases To Date</h3>
    </v-card-title>
    <v-card-text>      
      <canvas id="chart1" width="400" heigth="400"></canvas>
    </v-card-text>
  </v-card>
</template>

<script>
 import Chart from 'chart.js';
 import moment from 'moment';
 
 export default {
   props: ['purchasesinvoices'],
   data() {
     return {
       top: [],
     };
   },
   mounted() {
     this.purchasesInvoicesDraw();
   },
   watch: {
     purchasesinvoices() {
       this.top = [];
       this.purchasesinvoicesDraw();
     },
   },
   methods: {
     randomRGBA() {
       const o = Math.round;
       const r = Math.random;
       const s = 255;
       return `rgba(0,${o(r() * s)},${o(r() * s)},1)`;
     },
     purchasesInvoicesDraw() {
       const ctx = document.getElementById('chart1');
       const invoices = this.purchasesinvoices;
       const quantities = new Array(12).fill(0);
       invoices.forEach((invoice) => {
         const date = moment(invoice.DataDoc, 'YYYY-MM-DDThh:mm:ss');
         const month = date.format('M');
         if (quantities[month]) {
           quantities[month] += 1;
         } else {
           quantities[month] = 1;
         }
       });
       let sum = 0;
       const data = quantities.map(e => sum += e); // eslint-disable-line
       new Chart(ctx, { // eslint-disable-line no-new
         type: 'line',
         data: {
           labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
           datasets: [{
             fill: false,
             label: 'Number of purchases',
             backgroundColor: 'rgba(0,0,255,1)',
             borderColor: 'rgba(0,0,255,1)',
             data,
           }],
         },
         options: {
           responsive: true,
         },
       });
     },
   },
 };
</script>

<style scoped>
</style>