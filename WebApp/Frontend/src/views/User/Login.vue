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
                        <base-input :required="true"
                                    class="input-group-alternative mb-3"
                                    placeholder="Email"
                                    addon-left-icon="ni ni-email-83"
                                    @keyup.enter="login()"
                                    v-model="model.email">
                        </base-input>

                        <base-input :required="true"
                                    class="input-group-alternative"
                                    placeholder="Password"
                                    type="password"
                                    addon-left-icon="ni ni-lock-circle-open"
                                    @keyup.enter="login()"
                                    v-model="model.password">
                        </base-input>

                        <div class="text-center">
                            <base-button type="success" class="my-4" @click="login()">Entrar!</base-button>
                        </div>
                    </form>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-12 text-right">
                    <router-link to="/register" class="text-light"><small>Registrarme!</small></router-link>
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
        name: 'login',
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
                this.response = await api.userLogin(this.model);

                if (! this.response.Status) {
                    return;
                }

                store.state.user = this.response.Data;
                store.state.userType = 1;

                this.$router.push('/user/dashboard');
            }
        }
    }
</script>
<style>
</style>
