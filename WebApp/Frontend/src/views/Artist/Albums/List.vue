    <template>
    <div>
        <base-header class="header pb-8 pt-5 pt-lg-8 d-flex align-items-center"
                     style="min-height: 600px; background-image: url(img/theme/profile-cover.jpg); background-size: cover; background-position: center top;">
            <!-- Mask -->
            <span class="mask bg-gradient-success opacity-8"></span>
            <!-- Header container -->
            <div class="container-fluid d-flex align-items-center">
                <div class="row">
                    <div class="col-12">
                        <h1 class="display-2 text-white">Hola {{ getUserName() }}</h1>
                        <p class="text-white mt-0 mb-5">Ésta es la lista de Álbumes que tenés! Podés agregar, editar o eliminar cuando lo desees.</p>
                        <button @click="jumpTo('albums/add')" class="btn btn-success"><i class="fa fa-plus-circle"></i> Agregar álbum</button>
                    </div>
                </div>
            </div>
        </base-header>

        <div class="container-fluid mt--7">
            <div class="row">
                <div class="col-12">
                    <card shadow type="secondary">
                        <div slot="header" class="bg-white border-0">
                            <div class="row align-items-center">
                                <div class="col-8">
                                    <h3 class="mb-0">Lista de Álbumes</h3>
                                </div>
                            </div>
                            <div class="row">
                                <div class="table-responsive">
                                    <table class="table">
                                        <thead>
                                        <tr>
                                            <th>Nombre</th>
                                            <th>Tipo</th>
                                            <th>Estado</th>
                                            <th>Imagen</th>
                                            <th></th>
                                        </tr>
                                        </thead>
                                        <tbody>
                                        <tr v-for="album in albums" :key="album.Id">
                                            <th>{{ album.Name }}</th>
                                            <td>
                                                <base-alert type="primary" v-if="album.MediaType.Id === 1" style="width: 50px;height: 50px;">
                                                    <strong><i class="fa fa-music"></i></strong>
                                                </base-alert>
                                                <base-alert type="success" v-if="album.MediaType.Id === 2" style="width: 50px;height: 50px;">
                                                    <strong><i class="fa fa-video"></i></strong>
                                                </base-alert>
                                                <base-alert type="warning" v-if="album.MediaType.Id === 3" style="width: 50px;height: 50px;">
                                                    <strong><i class="fa fa-book"></i></strong>
                                                </base-alert>
                                                <base-alert type="danger" v-if="album.MediaType.Id === 4" style="width: 50px;height: 50px;">
                                                    <strong><i class="fa fa-image"></i></strong>
                                                </base-alert>
                                            </td>
                                            <td>{{ album.Status.Name }}</td>
                                            <td><img :src="album.ImageSource" alt="" style="height: 50px"></td>
                                            <td>
                                                <base-button @click="edit(album)" type="warning" icon="ni ni-tag" title="Editar"></base-button>
                                                <base-button @click="remove(album)" type="danger" icon="fa fa-times" title="Eliminar"></base-button>
                                            </td>
                                        </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </card>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import api from '@/api';
    import store from '@/store/index';

    export default {
        name: 'album-list',
        data() {
            return {
                albums: null
            }
        },
        async created() {
            const response = await api.albumFindAllByArtistId(store.state.user.Id);

            this.albums = response.Data;
        },
        methods: {
            getUserName() {
                return store.state.user.Name + " " + store.state.user.LastName;
            },
            jumpTo(url) {
                this.$router.push(url);
            },
            edit(album) {
                this.$router.push('albums/edit/' + album.Id);
            },
            remove(album) {
                album.Status.Name = 'Baja';
                api.albumRemove(album.Id);
            }
        }
    };
</script>
<style scoped>
    strong > i::before {
        margin-left: -7px!important;
    }
</style>
