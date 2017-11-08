<template>
  <div id="app">
    <hr>
    <router-link to="/sales">sales</router-link>
    <router-link to="/financial">financial</router-link>
    <router-link to="/overview">overview</router-link>
    <router-link to="/supplyChain">supply Chain</router-link>
    <hr>
    <router-view/>
    
  </div>
</template>

<script>
export default {
  name: 'app',
}
</script>

<style>
</style>
