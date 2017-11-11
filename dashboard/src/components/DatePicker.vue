<template>
  <div class="container">
    <div class="content">
      
      <div class="title">
        <h1>Time Interval</h1>
      </div>
      
      <div class="cell">
        <select v-model="fromYear">
          <option v-for="n in range(startYear, endYear)" :value="n">
            {{ n }}
          </option>
        </select>

        <select v-model="fromMonth">
          <option v-for="n in months(fromYear)" :value="n">
            {{ n }}
          </option>
        </select>

        <select v-model="toYear">
          <option v-for="n in range(fromYear, endYear)" :value="n">
            {{ n }}
          </option>
        </select>

        <select v-model="toMonth">
          <option v-for="n in months(toYear)" :value="n">
            {{ n }}
          </option>
        </select>
      </div>
      
    </div>
  </div>
</template>

<script>
 export default {
   data() {
     return {
       fromYear: '',
       fromMonth: '',
       toYear: '',
       toMonth: '',
     };
   },
   created() {
     this.fromYear = this.startYear;
     this.fromMonth = this.startMonth;
     this.toYear = this.endYear;
     this.toMonth = this.endMonth;
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
     months(year) {
       let range = [];
       switch (year) {
         case this.endYear:
           range = this.range(1, this.endMonth);
           break;
         case this.startYear:
           range = this.range(this.startMonth, 12);
           break;
         default:
           range = this.range(1, 12);
           break;
       }
       return range;
     },
   },
   props: ['startYear', 'startMonth', 'endYear', 'endMonth'],
   watch: {
     fromYear() {
       this.$emit('fromYear', this.fromYear);
     },
     fromMonth() {
       this.$emit('fromMonth', this.fromMonth);
     },
     toYear() {
       this.$emit('toYear', this.toYear);
     },
     toMonth() {
       this.$emit('toMonth', this.toMonth);
     },
   },
 };
</script>

<style scoped>
 .container {
     max-width: 100%;
     max-height: 100%;
     margin: 0;
     display: table;
     border-collapse: collapse;
 }

 .content {
     border: 1px solid black;
     display: table-row;
     height: 100%;
 }

 .title {
     text-align: left;
     vertical-align: middle;
     display: table-cell;
 }

 .cell {
     text-align: right;
     vertical-align: middle;
     display: table-cell;
 }
 
 h1 {
     margin: 0;
     padding: 0;
     font-size: 2vw;
     padding-left: 10px;
 }

 select {
     font-size: 1.4vw;
     margin-right: 10px;
 }

</style>
