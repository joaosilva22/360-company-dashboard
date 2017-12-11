<template>
  <v-app>

    <v-navigation-drawer fixed v-model="drawer" app>
      <v-toolbar flat>
        <v-list>
          <v-list-tile>
            <v-list-tile-title class="title">
              360º Company Dashboard
            </v-list-tile-title>
          </v-list-tile>
        </v-list>
      </v-toolbar>

      <v-divider></v-divider>

      <v-list dense>
        <v-list-tile router to="/" @click="overview()">
          <v-list-tile-action>
            <v-icon>home</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Overview</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>

        <v-list-tile router to="/Finances" @click="finances()">
          <v-list-tile-action>
            <v-icon>account_balance_wallet</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Finances</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>

        <v-list-tile router to="/Sales" @click="sales()">
          <v-list-tile-action>
            <v-icon>shopping_cart</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Sales</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>

        <v-list-tile router to="/SupplyChain" @click="supplyChain()">
          <v-list-tile-action>
            <v-icon>dashboard</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Supply Chain</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>

    <v-toolbar color="indigo" dark fixed app>
      <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
      <v-btn icon>
        <v-icon>arrow_back</v-icon>
      </v-btn>
      <v-toolbar-title>{{ title }}</v-toolbar-title>
    </v-toolbar>

    <v-content>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
export default {
  data: () => ({
    drawer: true,
    title: 'Overview',
  }),
  methods: {
    overview() {
      this.title = 'Overview';
    },
    sales() {
      this.title = 'Sales';
    },
    finances() {
      this.title = 'Finances';
    },
    supplyChain() {
      this.title = 'Supply Chain';
    },
  },
};
</script>

<style>
</style>
