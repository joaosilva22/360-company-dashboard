<template>
  <v-card>
    <v-card-title>
      <h3 class="headline mb-0">Product Performance</h3>
    </v-card-title>
    <v-card-text>      
      <canvas id="chart" width="400" heigth="400"></canvas>      
      <h5 class="subheading">Top Performers:</h5>      
      <p class="body-1 mb-0" v-for="(product, i) in top">
        {{ i+1 }}. {{ product.label }} ({{ product.quantity }} units)
      </p>
    </v-card-text>
  </v-card>
</template>

<script>
 import Sales from '@/services/Sales';
 import Chart from 'chart.js';
 
 export default {
   data() {
     return {
       top: [],
     };
   },
   props: ['year'],
   mounted() {
     const ctx = document.getElementById('chart');
     this.invoiceLines(this.year).then((res) => {
       const invoices = res.data.Invoices;
       const map = {};
       const labels = [];
       const data = [];
       const backgroundColor = [];
       invoices.forEach((invoice) => {
         const lines = invoice.Lines;
         lines.forEach((line) => {
           const productCode = line.ProductCode;
           const quantity = line.Quantity;
           const description = line.ProductDescription;
           if (map[productCode]) {
             const index = map[productCode];
             data[index] += quantity;
           } else {
             const index = data.length;
             map[productCode] = index;
             labels[index] = description;
             data[index] = quantity;
             backgroundColor[index] = this.randomRGBA();
           }
         });
       });
       new Chart(ctx, { // eslint-disable-line no-new
         type: 'doughnut',
         data: {
           labels,
           datasets: [{
             label: '# of Votes',
             data,
             backgroundColor,
           }],
         },
         options: {
           legend: {
             display: false,
           },
           responsive: true,
         },
       });
       this.top = this.top3(data, labels);
     });
   },
   methods: {
     invoiceLines(fiscalYear) {
       return Sales.invoiceLines(fiscalYear);
     },
     randomRGBA() {
       const o = Math.round;
       const r = Math.random;
       const s = 255;
       return `rgba(0,${o(r() * s)},${o(r()*s)},1)`;
     },
     top3(data, labels) {
       var outp = [];
       for (var i = 0; i < data.length; i += 1) {
         outp.push(i);
         if (outp.length > 3) {
             outp.sort((a, b) => data[b] - data[a]);
             outp.pop();
         }
       }
       const ret = [];
       outp.forEach((o) => {
         ret.push({
           label: labels[o],
           quantity: data[o],
         });
       });
       return ret;
     }
   },
 };
</script>

<style scop