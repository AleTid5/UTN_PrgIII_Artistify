<template>
    <div class="row justify-content-center">
        <message-error :hasError="! response.Status" :message="response.Data"></message-error>
        <div class="col-lg-5 col-md-7">
            <div class="card bg-secondary shadow border-0">
                <div class="card-body px-lg-5 py-lg-5">
                    <div class="text-center text-muted mb-4">
                        <router-link slot="brand" class="navbar-brand" to="/">
                            <img src="img/brand/white.png" style="width: 75px; height: 75px"/>
                        </router-link>
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

                        <div class="row">
                            <div class="col-4">
                                <base-radio :inline="true" name="M" class="mb-3" v-model="model.gender">
                                    Masculino
                                </base-radio>
                            </div>
                            <div class="col-4">
                                <base-radio :inline="true" name="F" class="mb-3" v-model="model.gender">
                                    Femenino
                                </base-radio>
                            </div>
                            <div class="col-4">
                                <base-radio :inline="true" name="O" class="mb-3" v-model="model.gender">
                                    Otro
                                </base-radio>
                            </div>
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
                        <div class="text-center">
                            <base-button native-type="submit" type="success" class="my-4">Crear cuenta</base-button>
                        </div>
                    </form>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-12 text-right">
                    <router-link to="/manager/login" class="text-light">
                        <small>Iniciar sesión</small>
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
    import MessageError from "../../components/Messages/Error";

    export default {
        name: 'register',
        components: {MessageError, flatPicker},
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
                },
                response: {
                    Status: true,
                    Data: null
                }
            }
        },
        methods: {
            async register() {
                this.response = await api.managerRegister(this.model);

                if (! this.response.Status) {
                    return;
                }

                this.$router.push('/manager/login');
            }
        }
    }
</script>
<style>
</style>
