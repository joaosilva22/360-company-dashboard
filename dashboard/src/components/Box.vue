<template>
  <v-card class="center">
    <v-card-title primary-title>
      <div>
        <h3 class="headline">{{ title }}</h3>
        <p class="mb-0" v-for="item in items">
          <span class="body-2" v-if="item.name"> {{ item.name }}:</span>
          <span class="body-1">{{ item.value }}</span>
        </p>
      </div>
    </v-card-title>
  </v-card>
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
</style>
