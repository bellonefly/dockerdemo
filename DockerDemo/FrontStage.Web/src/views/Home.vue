<template>
  <div class="home">
    HostName: {{hostName}}
    <br /><br />
    HostIP: {{hostIP}}
  </div>
</template>

<script>
// @ is an alias to /src
import axios from 'axios'
export default {
  name: 'home',
  data() {
    return {
      hostName: '',
      hostIP: ''
    }
  },

  mounted() {
    this.getInfo().then(response => {
      this.hostName = response.data.HostName
      this.hostIP = response.data.HostIP
    })
  },

  methods: {
    getInfo() {
      return axios.get('http://defsapi.demo.com/API/Info')
      // return axios.get('https://localhost:44318/API/Info')
    }
  }
}
</script>
