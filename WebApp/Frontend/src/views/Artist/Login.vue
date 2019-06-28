<template>
    <div class="row justify-content-center">
        <div class="col-lg-5 col-md-7">
            <div class="card bg-secondary shadow border-0">
                <div class="card-body px-lg-5 py-lg-5">
                    <div class="text-center text-muted mb-4">
                        <small>Inicio de sesión para <b>Artistas</b></small>
                    </div>
                    <form role="form">
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

                        <base-checkbox class="custom-control-alternative">
                            <span class="text-muted">Remember me</span>
                        </base-checkbox>
                        <div class="text-center">
                            <base-button type="primary" class="my-4" @click="login()">Iniciar sesión</base-button>
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

    export default {
        name: 'login-artist',
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
                const response = await api.artistLogin(this.model);

                if (! response.Status) {
                    // Todo: Error
                    return;
                }

                store.state.user = response.Data;
                store.state.userType = 2;

                this.$router.push('/artist/dashboard');
            }
        }
    }
</script>
<style>
</style>
