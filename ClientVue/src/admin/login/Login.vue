<template>
  <div id="app">
    <br>
    <br>
    <el-row type="flex" justify="center" align="middle" class="login-title">
      <el-col :span="10">
        <h2>Saving Little Souls Admin Login</h2>
      </el-col>
    </el-row>
    <br>
    <el-row type="flex" justify="center">
      <el-col id="login-container" :span="8">
        <el-form :model="modelToValidate" ref="validationForm" :rules="rules">
          <el-row type="flex" justify="center">
            <el-col :span="18">
              <h3 class="login-title">Please enter credentials</h3>
              <hr>
            </el-col>
          </el-row>
          <el-form-item prop="userName">
            <el-input v-model="modelToValidate.userName" @keyup.13.native="validateField('validationForm','userName')" placeholder="enter user name">
              <template slot="prepend"><i class="fa fa-user"></i></template>
            </el-input>
          </el-form-item>
          <el-form-item prop="password">
            <el-input v-model="modelToValidate.password" type="password" placeholder="enter password">
              <template slot="prepend"><i class="fa fa-lock"></i></template>
            </el-input>
          </el-form-item>
          <el-form-item>
            <el-button type="primary" @click="submitForm('validationForm')"><i class="fa fa-check"></i> Login</el-button>
            <el-button type="danger" @click="cancelLogin('validationForm')"><i class="fa fa-ban"></i> Cancel</el-button>
          </el-form-item>
        </el-form>
      </el-col>
    </el-row>
  </div>
</template>

<script>
  export default {
    name: 'app',
    data() {
      return {
        modelToValidate:{
          userName: '',
          password: ''
        },
        rules: {
          userName: [
            {required: true, message: 'user name is required', trigger: 'keyup'}
          ],
          password: [
            {required: true, message: 'password is required', trigger: 'keyup'}
          ]
        }
      }
    },
    methods: {
      submitForm(formName){
        this.$refs[formName].validate((valid)=>{
          if(valid){
            console.log('Form has been submitted');
          }else{
            console.log('Form is invalid and needs fixes.');
            return false;
          }
        });
      },
      cancelLogin(formName){
        this.$refs[formName].resetFields();
        console.log('Form has been reset.')
      },
      validateField(formName,fieldToValidate){
        this.$refs[formName].validateField(fieldToValidate,(errorMessage)=>{
          if(errorMessage){
            console.log(errorMessage);
            return false;
          }else{
            console.log('Valid userName');
          }
        });
      }
    }
  }
</script>

<style>
  .login-title {
    margin-bottom: 0;
    text-align: center;
  }

  #login-container {
    border: 1px solid #cccccc;
    -webkit-border-radius: 10px;
    -moz-border-radius: 10px;
    border-radius: 10px;
    padding-right: 20px;
    padding-left: 20px;
  }
</style>