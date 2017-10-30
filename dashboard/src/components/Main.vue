<template>
  <div id="container">
    <grid rows="12" cols="12">
      <grid-item row="1" height="12" col="1" width="3">
        <side-nav></side-nav>
      </grid-item>
      <grid-item row="1" height="12" col="4" width="9">
        <grid style="background-color:blue;" rows="12" cols="12">
        </grid>
      </grid-item>
    </grid>
  </div>
</template>

<script>
 import Grid from '@/components/Grid';
 import GridItem from '@/components/GridItem';
 
 export default {
   components: { Grid, GridItem },
 };
</script>

<style scoped>
 #container {
     width: 100%;
     height: 100%;
 }
</style>
