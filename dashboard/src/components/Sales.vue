<template>
  <div>
      <h1>Sales</h1>
  </div>
</template>

<script>
import Sales from '@/services/Sales'

export default {
  data() {
    return {
      timeTo: '01-10-2017',
      timeFrom: '01-11-2017'
    }
  },

  methods: {
    async salesBackloq() {
      try {
        await Sales.backloq({
          timeTo: this.timeTo,
          timeFrom: this.timeFrom
        })
      } catch (error) {
        this.error = error.response.data.error
      }
    }
  }
}
</script>

