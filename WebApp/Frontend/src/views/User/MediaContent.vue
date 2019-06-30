<template>
    <div>
        <div class="row">
            <div class="col-12">
                <base-button type="success" icon="ni ni-bold-left"@click="$router.back()">Atrás</base-button>
            </div>
        </div>
        <div class="row mt-5">
            <div class="col">
                <table-music v-if="mediaSelected === 1" title="Musica" :data="media"></table-music>
                <table-video v-if="mediaSelected === 2" title="Videos" :data="media"></table-video>
                <table-book v-if="mediaSelected === 3" title="Libros" :data="media"></table-book>
                <table-image v-if="mediaSelected === 4" title="Imagenes" :data="media"></table-image>
            </div>
        </div>
    </div>
</template>
<script>
    import api from "@/api";
    import store from "@/store/index";
    import TableMusic from "./Components/Table-Music";
    import TableVideo from "./Components/Table-Video";
    import TableBook from "./Components/Table-Book";
    import TableImage from "./Components/Table-Image";

    export default {
        components: {
            TableBook,
            TableImage,
            TableMusic,
            TableVideo
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
