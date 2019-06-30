<template>
    <div class="card shadow bg-dark">
        <div class="card-header border-0 bg-transparent">
            <div class="row align-items-center">
                <div class="col">
                    <h3 class="mb-0 text-white">
                        {{title}}
                    </h3>
                </div>
            </div>
        </div>

        <div class="table-responsive">
            <table class="table align-items-center table-flush">
                <thead>
                <th>Nombre</th>
                <th>Rating</th>
                <th>Genero</th>
                <th>Categoria</th>
                <th>Veces reproducida</th>
                <th></th>
                </thead>
                <tbody>
                <tr v-for="song in songs" :key="song.Id">
                    <th scope="row">
                        {{ song.Name }}
                    </th>
                    <td class="budget">
                        <rating @change="$emit('change')"
                                :rating="song.Rating"
                                :mediaId="song.Id"></rating>
                    </td>
                    <td class="budget">
                        {{song.Gender.Name}}
                    </td>
                    <td>{{ song.Category.Name }}</td>
                    <td>{{ song.ReproducedTimes }}</td>
                    <td>
                        <audio :src="song.Source" controls
                               v-if="getSongs[song.Id]"
                               @play="onPlay(song)">
                            <p>If you are reading this, it is because your browser does not support the audio element.</p>
                        </audio>
                    </td>
                </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
    import api from "@/api";
    import rating from "./Rating";

    export default {
        name: 'table-music',
        components: {
            rating
        },
        props: {
            type: {
                type: String
            },
            title: String,
            data: Array
        },
        beforeUpdate() {
            this.songs.map(song => this.files[song.Id] = true, this);
        },
        computed: {
            songs() {
                return this.data;
            },
            getSongs() {
                return this.files;
            }
        },
        data() {
            return {
                files: {}
            }
        },
        methods: {
            async onPlay(song) {
                song.ReproducedTimes++;
                await api.mediaAddReproducedTime({mediaId: song.Id});
            }
        },
    }
</script>
<style>
</style>
