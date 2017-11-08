<template>
  <div :style="style">
    <slot></slot>
  </div>
</template>

<script>
 export default {
   props: ['row', 'col', 'width', 'height'],
   computed: {
     style() {
       return `grid-row: ${this.row} / span ${this.height}; grid-column: ${this.col} / span ${this.width};`
     }
   }
 }
</script>

<style scoped>
</style>
