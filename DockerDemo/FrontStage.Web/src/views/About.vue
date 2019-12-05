<template>
  <div class="about">
    <h1>My name is {{ name }}</h1>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      name: ''
    }
  },

  mounted() {
    this.getName().then(response => {
      this.name = response.data
    })
  },

  methods: {
    getName() {
      return axios.get('http://defsapi.demo.com/API/Member')
    }
  }
}
</script>
