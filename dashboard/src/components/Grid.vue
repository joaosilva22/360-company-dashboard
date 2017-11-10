<template>
  <div :style="style">
    <slot></slot>
  </div>
</template>

<script>
 export default {
   props: ['rows', 'cols'],
   computed: {
     style() {
       return `grid-template: repeat(${this.rows}, 1fr) / repeat(${this.cols}, 1fr); grid-column-gap: 5px; grid-row-gap: 5px; padding: 5px;`;
     },
   },
 };
</script>

<style scoped>
 div {
     width: 100%;
     height: 100%;
     display: grid;
 }
</style>
