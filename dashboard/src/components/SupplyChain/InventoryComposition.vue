<template>
  <v-card>
    <v-card-title>
      <h3 class="headline mb-0">Inventory Composition</h3>
    </v-card-title>
    <v-card-text>      
      <canvas id="chartinventoryComposition" width="400" heigth="400"></canvas>      
      <h5 class="subheading">Top Stock:</h5>      
      <p class="body-1 mb-0" v-for="(product, i) in products">
        {{ i+1 }}. {{ product.label }} ({{ product.quantity }} units)
      </p>
    </v-card-text>
  </v-card>
</template>

<script>
 import Chart from 'chart.js';
 
 export default {
   props: ['inventorycomposition'],
   data() {
     return {
       products: [],
     };
   },
   create() {
     this.getInventory();
   },
   watch: {
     inventorycomposition() {
       this.products = [];
       this.getInventory();
     },
   },
   methods: {
     randomRGBA() {
       const o = Math.round;
       const r = Math.random;
       const s = 255;
       return `rgba(0,${o(r() * s)},${o(r() * s)},1)`;
     },
     top3(data, labels) {
       const outp = [];
       for (let i = 0; i < data.length; i += 1) {
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
     },
     getInventory() {
       const ctx = document.getElementById('chartinventoryComposition');
       const articles = this.inventorycomposition;

       const map = {};
       const labels = [];
       const data = [];
       const backgroundColor = [];
       articles.forEach((article) => {
         const productCode = article.CodArtigo;
         const quantity = article.STKActual;
         const description = article.DescArtigo;
         if (map[productCode]) {
           const index = map[productCode];
           data[index] += Math.abs(quantity);
         } else {
           const index = data.length;
           map[productCode] = index;
           labels[index] = description;
           data[index] = Math.abs(quantity);
           backgroundColor[index] = this.randomRGBA();
         }
       });
       new Chart(ctx, { // eslint-disable-line no-new
         type: 'doughnut',
         data: {
           labels,
           datasets: [{
             label: 'Number of units',
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
       this.products = this.top3(data, labels);
     },
   },
 };
</script>

<style scoped>
</style>