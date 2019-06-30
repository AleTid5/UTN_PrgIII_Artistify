<template>
    <div>
        <div class="row">
            <div class="col-12">
                <base-button type="success" icon="ni ni-bold-left"@click="$router.back()">Atrás</base-button>
            </div>
        </div>
        <div class="row">
            <div class="col-xl-2 order-xl-2 mb-5 mb-xl-0 mt-5"
                 style="cursor: pointer;"
                 v-for="album in albums" :key="album.Id"
                 @click="onAlbumSelected(album.Id)"
            >
                <div class="card card-profile shadow">
                    <div class="row justify-content-center">
                        <div class="col-lg-3 order-lg-2">
                            <div class="card-profile-image">
                                <a href="#">
                                    <img v-bind:src="album.ImageSource" class="rounded-circle" style="height: 100px;width: 100px;">
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="card-body pt-0 pt-md-4">
                        <div class="row">
                            <div class="col">
                                <div class="card-profile-stats d-flex justify-content-center">
                                    <div>
                                        <span class="heading"></span>
                                        <span class="description"></span>
                                    </div>
                                    <div>
                                        <span class="heading"></span>
                                        <span class="description"></span>
                                    </div>
                                    <div>
                                        <span class="heading"></span>
                                        <span class="description"></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="text-center">
                            <h3>
                                {{ album.Name }}<span class="font-weight-light"></span>
                            </h3>
                            <div class="h5 font-weight-300">
                                <i class="ni location_pin mr-2"></i>({{ album.Artist.Alias }})
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import api from "@/api";
    import store from "@/store/index";

    export default {
        data() {
            return {
                albums: []
            };
        },
        methods: {
            onAlbumSelected(id) {
                store.state.albumSelected = id;
                this.$router.push('albums/mediaContent');
            }
        },

        async created() {
            const response = await api.mediaFindById(store.state.mediaTypeSelected);

            if (! response.Status) {
                // ToDo: Error..
                return;
            }

            this.albums = response.Data;
        },
    };
</script>
<style></style>
