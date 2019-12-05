<template>
  <div class="about">
    Id: {{ id }} <br /><br />
    Name: {{ name }}
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
    this.getData().then(response => {
      this.id = response.data.Id
      this.name = response.data.Name
    })
  },

  methods: {
    getData() {
      return axios.get('http://defsapi.demo.com/API/Redis')
      // return axios.get('https://localhost:44318/API/Redis')
    }
  }
}
</script>
