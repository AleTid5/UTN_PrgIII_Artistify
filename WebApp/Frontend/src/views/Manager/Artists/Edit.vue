<template>
    <div>
        <message-error :hasError="! response.Status" :message="response.Data"></message-error>
        <base-header class="header pb-8 pt-5 pt-lg-8 d-flex align-items-center bg-success" style="min-height: 100px">
        </base-header>
        <div class="container-fluid mt--7">
            <div class="row">
                <div class="col-12">
                    <card shadow type="secondary">
                        <div slot="header" class="bg-white border-0">
                            <div class="row align-items-center">
                                <div class="col-8">
                                    <h3 class="mb-0">Agregar nuevo artista</h3>
                                </div>
                                <div class="col-4 text-right">
                                    <base-button type="success" icon="ni ni-bold-left"@click="$router.back()">Volver</base-button>
                                </div>
                            </div>
                        </div>
                        <template>
                            <form @submit.prevent @submit="edit()">
                                <h6 class="heading-small text-muted mb-4">Información básica del Artista</h6>
                                <div class="pl-lg-4">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <base-input class="input-group-alternative mb-3"
                                                        placeholder="Nombre"
                                                        addon-left-icon="ni ni-single-02"
                                                        v-model="model.name">
                                            </base-input>
                                        </div>
                                        <div class="col-lg-6">
                                            <base-input :required="true"
                                                        class="input-group-alternative mb-3"
                                                        placeholder="Apellido"
                                                        addon-left-icon="ni ni-single-02"
                                                        v-model="model.lastname">
                                            </base-input>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <base-input class="input-group-alternative mb-3"
                                                        placeholder="Email"
                                                        addon-left-icon="ni ni-email-83"
                                                        v-model="model.email">
                                            </base-input>
                                        </div>
                                        <div class="col-lg-6">
                                            <base-input class="input-group-alternative mb-3"
                                                        placeholder="Alias"
                                                        addon-left-icon="ni ni-single-02"
                                                        v-model="model.alias">
                                            </base-input>
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-4" />
                                <!-- Address -->
                                <h6 class="heading-small text-muted mb-4">Informacion general</h6>
                                <div class="pl-lg-4">
                                    <div class="row">
                                        <div class="col-md-6">
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
                                        </div>
                                        <div class="col-md-6">
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
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-4">
                                                    <base-radio :inline="true" name="A" class="mb-3" v-model="model.status">
                                                        Alta
                                                    </base-radio>
                                                </div>
                                                <div class="col-4">
                                                    <base-radio :inline="true" name="B" class="mb-3" v-model="model.status">
                                                        Baja
                                                    </base-radio>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-4">
                                <div class="text-center">
                                    <base-button native-type="submit" type="success" class="my-4"><i class="fa fa-user"></i> Editar cuenta</base-button>
                                </div>
                            </form>
                        </template>
                    </card>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import api from '@/api';
    import MessageError from "../../../components/Messages/Error";
    import store from '@/store/index';
    import flatPicker from "vue-flatpickr-component";
    import "flatpickr/dist/flatpickr.css";

    export default {
        name: 'artist-edit',
        components: {MessageError, flatPicker},
        data() {
            return {
                model: {
                    id: null,
                    name: null,
                    lastname: null,
                    borndate: null,
                    gender: null,
                    email: null,
                    status: null,
                    alias: null
                },
                response: {
                    Status: true,
                    Data: null
                }
            }
        },
        async created() {
            this.response = await api.artistFindById(store.state.user.Id, this.$route.params.artistId);

            if (! this.response.Status) {
                return;
            }

            this.model.id = this.$route.params.artistId;
            this.model.name = this.response.Data.Name;
            this.model.lastname = this.response.Data.LastName;
            this.model.borndate = this.response.Data.BornDate;
            this.model.gender = this.response.Data.Gender;
            this.model.email = this.response.Data.Email;
            this.model.status = this.response.Data.Status.Code;
            this.model.alias = this.response.Data.Alias;
        },
        methods: {
            async edit() {
                this.response = await api.artistEdit(this.model);

                if (! this.response.Status) {
                    return;
                }

                this.$router.push('/manager/artists');
            }
        }
    };
</script>
<style></style>
