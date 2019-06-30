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
                                <h6 class="heading-small text-muted mb-4">Informacion general</h6>
                                <div class="pl-lg-4">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <base-input class="input-group-alternative"
                                                        placeholder="Nombre del album"
                                                        addon-left-icon="ni ni-diamond"
                                                        v-model="model.name">
                                            </base-input>
                                        </div>
                                        <div class="col-md-4">
                                            <base-input class="input-group-alternative"
                                                        placeholder="URL de Imagen"
                                                        addon-left-icon="ni ni-world"
                                                        v-model="model.imageSource">
                                            </base-input>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-4">
                                                    <base-radio :inline="true" name="A" class="mb-3" v-model="model.status">
                                                        Activo
                                                    </base-radio>
                                                </div>
                                                <div class="col-4">
                                                    <base-radio :inline="true" name="B" class="mb-3" v-model="model.status">
                                                        Baja
                                                    </base-radio>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <label>Tipo de álbum</label>
                                            <div class="row">
                                                <div class="col-3">
                                                    <base-radio :inline="true" name="1" class="mb-3" v-model="model.mediaType">
                                                        <i class="fa fa-music"></i><b> Música</b>
                                                    </base-radio>
                                                </div>
                                                <div class="col-3">
                                                    <base-radio :inline="true" name="2" class="mb-3" v-model="model.mediaType">
                                                        <i class="fa fa-video"></i><b> Videos</b>
                                                    </base-radio>
                                                </div>
                                                <div class="col-3">
                                                    <base-radio :inline="true" name="3" class="mb-3" v-model="model.mediaType">
                                                        <i class="fa fa-book"></i><b> Libros</b>
                                                    </base-radio>
                                                </div>
                                                <div class="col-3">
                                                    <base-radio :inline="true" name="4" class="mb-3" v-model="model.mediaType">
                                                        <i class="fa fa-image"></i><b> Imágenes</b>
                                                    </base-radio>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-4">
                                <div class="text-center">
                                    <base-button native-type="submit" type="success" class="my-4"><i class="fa fa-tag"></i> Editar álbum</base-button>
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
                    status: null,
                    mediaType: null,
                    imageSource: null,
                },
                response: {
                    Status: true,
                    Data: null
                }
            }
        },
        async created() {
            console.log(this.$route.params);
            this.response = await api.albumArtistFindById(this.$route.params.albumId);

            if (! this.response.Status) {
                return;
            }

            this.model.id = this.$route.params.albumId;
            this.model.name = this.response.Data.Name;
            this.model.status = this.response.Data.Status.Code;
            this.model.mediaType = this.response.Data.MediaType.Id;
            this.model.imageSource = this.response.Data.ImageSource;
        },
        methods: {
            async edit() {
                this.response = await api.albumEdit(this.model);

                if (! this.response.Status) {
                    return;
                }

                this.$router.push('/artist/albums')
            }
        }
    };
</script>
<style></style>
