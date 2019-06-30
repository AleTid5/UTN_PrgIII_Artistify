<template>
    <div class="row justify-content-center">
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
                                    v-model="model.email">
                        </base-input>

                        <base-input :required="true"
                                    class="input-group-alternative"
                                    placeholder="Password"
                                    type="password"
                                    addon-left-icon="ni ni-lock-circle-open"
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

    export default {
        name: 'login',
        data() {
            return {
                model: {
                    email: '',
                    password: ''
                }
            }
        },
        methods: {
            async login() {
                const response = await api.userLogin(this.model);

                if (! response.Status) {
                    // Todo: Error
                    return;
                }

                store.state.user = response.Data;
                store.state.userType = 1;

                this.$router.push('/user/dashboard');
            }
        }
    }
</script>
<style>
</style>
