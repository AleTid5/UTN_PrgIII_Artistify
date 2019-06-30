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
                                    <h3 class="mb-0">Agregar nuevo contenido digital</h3>
                                </div>
                            </div>
                        </div>
                        <template>
                            <form @submit.prevent @submit="register()">
                                <h6 class="heading-small text-muted mb-4">Información básica del Contenido</h6>
                                <div class="pl-lg-4">
                                    <div class="row">
                                        <el-select v-model="model.album"
                                                   class="col-6"
                                                   filterable
                                                   placeholder="Seleccioná el Album">
                                            <el-option
                                                    v-for="album in albums"
                                                    :key="album.Id"
                                                    :label="album.Name"
                                                    :value="album.Id"
                                                    :disabled="album.Status.Code === 'B'">
                                            </el-option>
                                        </el-select>

                                        <div class="col-lg-6">
                                            <base-input :required="true"
                                                        class="input-group-alternative mb-3"
                                                        placeholder="Nombre"
                                                        addon-left-icon="ni ni-folder-17"
                                                        v-model="model.name">
                                            </base-input>
                                        </div>
                                        <el-select v-model="model.gender"
                                                   class="col-6"
                                                   filterable
                                                   placeholder="Seleccioná el Album">
                                            <el-option
                                                    v-for="gender in genders"
                                                    :key="gender.Id"
                                                    :label="gender.Name"
                                                    :value="gender.Id"
                                                    :disabled="gender.Status.Code === 'B'">
                                            </el-option>
                                        </el-select>
                                        <el-select v-model="model.category"
                                                   class="col-6"
                                                   filterable
                                                   placeholder="Seleccioná el Album">
                                            <el-option
                                                    v-for="category in categories"
                                                    :key="category.Id"
                                                    :label="category.Name"
                                                    :value="category.Id"
                                                    :disabled="category.Status.Code === 'B'">
                                            </el-option>
                                        </el-select>
                                    </div>
                                </div>
                                <hr class="my-4" />
                                <!-- Address -->
                                <h6 class="heading-small text-muted mb-4">Carga de archivo</h6>
                                <div class="pl-lg-4">
                                    <div class="row">
                                        <div class="col-12">
                                            <input type="file" ref="file" class="form-control">
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-4">
                                <div class="text-center">
                                    <base-button native-type="submit" type="success" class="my-4"><i class="fa fa-plus"></i> Crear contenido</base-button>
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
    import Vue from 'vue';
    import 'element-ui/lib/theme-chalk/index.css';
    import { Select, Option } from 'element-ui';

    export default {
        name: 'artist-add',
        components: {MessageError, flatPicker, [Select.name]: Select, [Option.name]: Option},
        data() {
            return {
                model: {
                    album: null,
                    name: null,
                    gender: null,
                    category: null,
                    mediaType: 4
                },
                response: {
                    Status: true,
                    Data: null
                },
                albums: null,
                genders: null,
                categories: null
            }
        },
        async created() {
            const albums = await api.albumFindAllByArtistId(store.state.user.Id);
            this.albums = albums.Data;

            const genders = await api.gendersFindAll();
            this.genders = genders.Data;

            const categories = await api.categoriesFindAll();
            this.categories = categories.Data;
        },
        methods: {
            async register() {
                let formData = new FormData();
                formData.append('file', this.$refs.file.files[0]);
                formData.append('json', JSON.stringify({form: this.model}));

                this.response = await api.mediaAdd(formData);

                if (! this.response.Status) {
                    return;
                }

                this.$router.back();
            }
        },
        watch: {
            'model.album'(id) {
                const album = this.albums.filter(album => album.Id === id)[0];
                this.model.mediaType = album.MediaType.Id;
            }
        }
    };
</script>
<style></style>
