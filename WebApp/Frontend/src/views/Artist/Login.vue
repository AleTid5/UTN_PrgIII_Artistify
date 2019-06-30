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
                    <form role="form">
                        <base-input class="input-group-alternative mb-3"
                                    placeholder="Email"
                                    addon-left-icon="ni ni-email-83"
                                    @keyup.enter="login()"
                                    v-model="model.email">
                        </base-input>

                        <base-input class="input-group-alternative"
                                    placeholder="Password"
                                    type="password"
                                    addon-left-icon="ni ni-lock-circle-open"
                                    @keyup.enter="login()"
                                    v-model="model.password">
                        </base-input>

                        <base-checkbox class="custom-control-alternative">
                            <span class="text-muted">Remember me</span>
                        </base-checkbox>
                        <div class="text-center">
                            <base-button type="success" class="my-4" @click="login()">Iniciar sesión</base-button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import api from '@/api';
    import store from '@/store/index';
    import MessageError from "../../components/Messages/Error";

    export default {
        name: 'login-artist',
        components: {MessageError},
        data() {
            return {
                model: {
                    email: '',
                    password: ''
                },
                response: {
                    Status: true,
                    Data: null
                }
            }
        },
        methods: {
            async login() {
                this.response = await api.artistLogin(this.model);

                if (! this.response.Status) {
                    return;
                }

                store.state.user = this.response.Data;
                store.state.userType = 2;

                this.$router.push('/artist/dashboard');
            }
        }
    }
</script>
<style>
</style>
