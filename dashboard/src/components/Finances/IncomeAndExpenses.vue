<template>
  <v-card>
    <v-card-title>
      <h3 class="headline mb-0">Income and Expenses</h3>
    </v-card-title>
    <v-card-text>      
      <canvas id="chartIncomeAndExpenses" width="400" heigth="400"></canvas>      
    </v-card-text>
  </v-card>
</template>

<script>
 import Account from '@/services/Account';
 import Chart from 'chart.js';
 
 export default {
   data() {
     return {};
   },
   props: ['year'],
   mounted() {
     const ctx = document.getElementById('chartIncomeAndExpenses');
     this.getIncomeAndExpenses(this.year).then((res) => {
       const labels = ['Income', 'Expenses'];
       const data = [res.data.incomeMoney, res.data.expensesMoney];
       console.log(data);
       const backgroundColor = [this.randomRGBA(), this.randomRGBA()];
       new Chart(ctx, { // eslint-disable-line no-new
         type: 'bar',
         data: {
           labels,
           datasets: [{
             // label: 'Number of units sold',
             data,
             backgroundColor,
           }],
         },
         options: {
           scales: {
             yAxes: [{
               ticks: {
                 suggestedMin: 50,
                 suggestedMax: 100,
               },
             }],
           },
           responsive: true,
           legend: {
             display: false,
           },
         },
       });
     });
   },
   methods: {
     getIncomeAndExpenses(fiscalYear) {
       return Account.incomeAndExpenses(fiscalYear);
     },
     randomRGBA() {
       const o = Math.round;
       const r = Math.random;
       const s = 255;
       return `rgba(0,${o(r() * s)},${o(r() * s)},1)`;
     },
   },
 };
</script>

<style scoped>
</style>