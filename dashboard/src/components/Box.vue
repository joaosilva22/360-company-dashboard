<template>
  <div class="container">
    <h1>{{ title }}</h1>
    <div class="content">
      <div class="cell">
        <p v-for="item in items">
          <span v-if="item.name"> {{ item.name }}:</span>
          {{ item.value }}
        </p>
      </div>
    </div>
  </div>
</template>

<script>
 export default {
   data() {
     return {};
   },
   props: ['title', 'items'],
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

 .cell {
     text-align: center;
     vertical-align: middle;
     display: table-cell;
 }

 h1 {
     margin: 0;
     padding: 0;
     font-size: 3vw;
 }

 p {
     margin: 0;
     padding: 0;
     font-size: 2vw;
 }
</style>
