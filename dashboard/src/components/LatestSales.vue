<template>
  <v-data-table
      v-bind:headers="headers"
      :items="items"
      hide-actions
      class="elevation-2"
    >
    <template slot="items" scope="props">
      <td class="text-xs-right">{{ props.item.customer }}</td>
      <td class="text-xs-right">{{ props.item.date }}</td>
      <td class="text-xs-right">{{ props.item.value }}</td>
    </template>
  </v-data-table>
</template>

<script>
  export default {
    data() {
      return {
        headers: [
          {
            text: 'Customer',
            sortable: false,
            value: 'name',
          },
          { text: 'Date', value: 'date' },
          { text: 'Value', value: 'value' },
        ],
        items: [
          {
            customer: 'Frozen Yogurt',
            date: '2017-03-12',
            value: 10,
          },
          {
            customer: 'Frozenasas Yogurt',
            date: '2017-03-13',
            value: 13,
          },
        ],
      };
    },
  };
</script>