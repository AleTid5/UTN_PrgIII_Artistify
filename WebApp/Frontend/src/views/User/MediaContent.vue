<template>
    <div>
        <base-header type="gradient-success" class="pb-6 pb-8 pt-5 pt-md-8">
            <div class="row">
                <base-button type="primary" icon="ni ni-bold-left"@click="$router.back()">Back</base-button>
            </div>
            <div class="row mt-5">
                <div class="col">
                    <music-table v-if="mediaSelected === 1" title="Tabla de musica" :data="media"></music-table>
                </div>
            </div>
        </base-header>
    </div>
</template>
<script>
    import api from "@/api";
    import store from "@/store/index";
    import MusicTable from "./MusicTable";

    export default {
        components: {
            MusicTable
        },
        data() {
            return {
                media: [],
                mediaSelected: store.state.mediaTypeSelected
            };
        },
        methods: {
        },

        async created() {
            const response = await api.albumFindById(store.state.albumSelected);

            if (! response.Status) {
                // ToDo: Error..
                return;
            }

            this.media = response.Data;
            console.log(this.media)
        },
    };
</script>
<style></style>
