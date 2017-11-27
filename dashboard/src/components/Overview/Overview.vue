<template>
<v-container fluid grid-list-md>
    <v-layout row wrap>
      <v-flex xs12>
        <date-picker
        start="2016"
        end="2016"
        @year="updateYear"
        >
        </date-picker>
      </v-flex>
            
      <v-flex xs4 d-flex>
        <v-layout row wrap>
          <v-flex d-flex>
            <inventory-composition></inventory-composition>
          </v-flex>
          <v-flex d-flex>
            <inventory-value></inventory-value>
          </v-flex>
        </v-layout>
      </v-flex>

      <v-flex xs4 d-flex>
        <product-performance></product-performance>
      </v-flex>

    </v-layout>
  </v-container>
</template>


<script>
import DatePicker from '@/components/DatePicker';
import InventoryValue from '@/components/SupplyChain/InventoryValue';
import InventoryComposition from '@/components/SupplyChain/InventoryComposition';
import ProductPerformance from '@/components/Sales/ProductPerformance';

export default {
  data() {
    return {
      year: '0',
    };
  },
  components: {
    DatePicker,
    InventoryValue,
    InventoryComposition,
    ProductPerformance,
  },
  methods: {
    updateYear(value) {
      this.year = value;
    },
  },
};
</script>

<style scoped>
</style>