<template>
    <div class="row justify-content-center">
        <div class="col-lg-5 col-md-7">
            <div class="card bg-secondary shadow border-0">
                <div class="card-body px-lg-5 py-lg-5">
                    <div class="text-center text-muted mb-4">
                        <small>Or sign up with credentials</small>
                    </div>
                    <form role="form" @submit="register()">
                        <base-input class="input-group-alternative mb-3"
                                    placeholder="Nombre"
                                    addon-left-icon="ni ni-single-02"
                                    v-model="model.name">
                        </base-input>

                        <base-input :required="true"
                                    class="input-group-alternative mb-3"
                                    placeholder="Apellido"
                                    addon-left-icon="ni ni-single-02"
                                    v-model="model.lastname">
                        </base-input>

                        <base-input :required="true"
                                    addon-left-icon="ni ni-calendar-grid-58">
                            <flat-picker slot-scope="{focus, blur}"
                                         @on-open="focus"
                                         @on-close="blur"
                                         :config="{allowInput: true}"
                                         class="form-control datepicker"
                                         v-model="model.borndate">
                            </flat-picker>
                        </base-input>

                        <div>
                            <base-radio :inline="true" name="M" class="mb-3" v-model="model.gender">
                                Masculino
                            </base-radio>
                            <base-radio :inline="true" name="F" class="mb-3" v-model="model.gender">
                                Femenino
                            </base-radio>
                            <base-radio :inline="true" name="O" class="mb-3" v-model="model.gender">
                                Otro
                            </base-radio>
                        </div>

                        <base-input class="input-group-alternative mb-3"
                                    placeholder="Numero de telefono"
                                    addon-left-icon="fa fa-phone-square"
                                    v-model="model.telephone">
                        </base-input>

                        <base-input class="input-group-alternative mb-3"
                                    placeholder="CUIT"
                                    addon-left-icon="fa fa-id-card"
                                    v-model="model.cuit">
                        </base-input>

                        <base-input class="input-group-alternative mb-3"
                                    placeholder="Email"
                                    addon-left-icon="ni ni-email-83"
                                    v-model="model.email">
                        </base-input>

                        <base-input class="input-group-alternative"
                                    placeholder="Password"
                                    type="password"
                                    addon-left-icon="ni ni-lock-circle-open"
                                    v-model="model.password">
                        </base-input>

                        <div class="row my-4">
                            <div class="col-12">
                                <base-checkbox class="custom-control-alternative">
                                    <span class="text-muted">I agree with the <a href="#!">Privacy Policy</a></span>
                                </base-checkbox>
                            </div>
                        </div>
                        <div class="text-center">
                            <base-button native-type="submit" type="primary" class="my-4">Create account</base-button>
                        </div>
                    </form>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-6">
                    <a href="#" class="text-light">
                        <small>Forgot password?</small>
                    </a>
                </div>
                <div class="col-6 text-right">
                    <router-link to="/login" class="text-light">
                        <small>Login into your account</small>
                    </router-link>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import api from '@/api';
    import flatPicker from "vue-flatpickr-component";
    import "flatpickr/dist/flatpickr.css";

    export default {
        name: 'register',
        components: {flatPicker},
        data() {
            return {
                model: {
                    name: null,
                    lastname: null,
                    borndate: null,
                    gender: null,
                    telephone: null,
                    cuit: null,
                    email: null,
                    password: null
                }
            }
        },
        methods: {
            async register() {
                const response = await api.managerRegister(this.model);

                if (! response.Status) {
                    // Todo: Error
                    return;
                }

                this.$router.push('/manager/login');
            }
        }
    }
</script>
<style>
</style>
