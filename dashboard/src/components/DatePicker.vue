<template>
<v-card>
    <v-card-text style="padding: 0">
      <v-container fluid>
        <v-layout row wrap>
          <v-flex xs6>
            <h3 class="headline" style="margin-top: 20px">Fiscal Year {{this.end}}</h3>
          </v-flex>
          <v-flex xs6>
            <v-select
              v-bind:items="range(start, end)"
              v-model="year"
              label="Select"
              single-line
              bottom
            ></v-select>
          </v-flex>
        </v-layout>
      </v-container>
    </v-card-text>
  </v-card>
</template>

<script>
 export default {
   data() {
     return {
       year: '',
     };
   },
   created() {
     this.year = this.start;
   },
   methods: {
     range(min, max) {
       const arr = [];
       let i = parseInt(min, 10);
       while (i <= parseInt(max, 10)) {
         arr.push(i);
         i += 1;
       }
       return arr;
     },
   },
   props: ['start', 'end'],
   watch: {
     year() {
       this.$emit('year', this.year);
     },
   },
 };
</script>

<style scoped>
</style>
