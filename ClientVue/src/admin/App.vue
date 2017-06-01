<template>
  <div id="app" class="container">
    <h2>Admin Page</h2>
  </div>
</template>

<script>
  export default {
    name: 'app',
    data() {
      return {
        toasterTitle: '',
        toasterText: ''
      }
    },
    methods: {
      showToastr() {
        if (this.toasterTitle.length <= 0 || this.toasterText.length <= 0) {

        } else {

        }
      }
    }
  }
</script>