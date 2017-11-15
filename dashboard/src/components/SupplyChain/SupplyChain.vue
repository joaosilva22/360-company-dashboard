<template>
  <grid rows="7" cols="12">
     <grid-item row="1" height="1" col="1" width="12">
       <date-picker
        start="2016"
        end="2016"
        @year="updateYear"
        >
       </date-picker>
     </grid-item>
     <grid-item row="2" height="2" col="1" width="9">
        <latest-purchases></latest-purchases>
     </grid-item>
    <grid-item row="2" height="1" col="10" width="3">
       <total-purchases></total-purchases>
     </grid-item>
     <grid-item row="3" height="1" col="10" width="3">
       <inventory-value></inventory-value>
     </grid-item>
     <grid-item row="4" height="2" col="1" width="9">
       <accounts-payable></accounts-payable>
     </grid-item>
 
    <grid-item row="6" height="2" col="1" width="9">
       <top-supplier></top-supplier>
     </grid-item> 
   </grid>
</template>


<script>
import Grid from '@/components/Grid';
import GridItem from '@/components/GridItem';
import DatePicker from '@/components/DatePicker';
import LatestPurchases from '@/components/SupplyChain/LatestPurchases';
import TopSupplier from '@/components/SupplyChain/TopSupplier';
import AccountsPayable from '@/components/SupplyChain/AccountsPayable';
import InventoryValue from '@/components/SupplyChain/InventoryValue';
import TotalPurchases from '@/components/SupplyChain/TotalPurchases';

export default {
  data() {
    return {
      fromYear: 0,
      fromMonth: 0,
      toYear: 0,
      toMonth: 0,
    };
  },
  components: {
    Grid,
    GridItem,
    DatePicker,
    LatestPurchases,
    TopSupplier,
    AccountsPayable,
    InventoryValue,
    TotalPurchases,
  },
  methods: {
    updateYear(value) {
      this.year = value;
    },
  },
};
</script>

