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
                        <p class="text-white mt-0 mb-5">Ésta es la lista de Artistas que maneja. Puede agregar, editar o eliminar cuando usted lo desee.</p>
                        <button @click="jumpTo('artists/add')" class="btn btn-success"><i class="fa fa-user-plus"></i> Agregar artista</button>
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
                                    <h3 class="mb-0">Lista de Artistas</h3>
                                </div>
                            </div>
                            <div class="row">
                                <div class="table-responsive">
                                    <table class="table">
                                        <thead>
                                        <tr>
                                            <th>Alias</th>
                                            <th>Nombre</th>
                                            <th>Apellido</th>
                                            <th>Estado</th>
                                            <th>E-Mail</th>
                                            <th>Fecha de nacimiento</th>
                                            <th>Genero</th>
                                            <th></th>
                                        </tr>
                                        </thead>
                                        <tbody>
                                        <tr v-for="artist in artists" :key="artist.Id">
                                            <th>{{ artist.Alias }}</th>
                                            <td>{{ artist.Name }}</td>
                                            <td>{{ artist.LastName }}</td>
                                            <td>{{ artist.Status.Name }}</td>
                                            <td>{{ artist.Email }}</td>
                                            <td>{{ artist.BornDate }}</td>
                                            <td>{{ artist.Gender }}</td>
                                            <td>
                                                <base-button @click="edit(artist)" type="warning" icon="fa fa-user" title="Editar"></base-button>
                                                <base-button @click="remove(artist)" type="danger" icon="fa fa-user-times" title="Eliminar"></base-button>
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
        name: 'artist-list',
        data() {
            return {
                artists: null
            }
        },
        async created() {
            const response = await api.artistFindAll(store.state.user.Id);

            this.artists = response.Data;
        },
        methods: {
            getUserName() {
                return store.state.user.Name + " " + store.state.user.LastName;
            },
            jumpTo(url) {
                this.$router.push(url);
            },
            edit(artist) {
                this.$router.push('artists/edit/' + artist.Id);
            },
            remove(artist) {
                artist.Status.Name = 'Baja';
                api.artistRemove(artist.Id);
            }
        }
    };
</script>
<style></style>
