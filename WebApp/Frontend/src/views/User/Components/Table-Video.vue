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
                <th>Veces reproducido</th>
                <th></th>
                </thead>
                <tbody>
                <tr v-for="video in videos" :key="video.Id">
                    <th scope="row">
                        {{ video.Name }}
                    </th>
                    <td class="budget">
                        <rating @change="$emit('change')"
                                :rating="video.Rating"
                                :mediaId="video.Id"></rating>
                    </td>
                    <td class="budget">
                        {{video.Gender.Name}}
                    </td>
                    <td>{{ video.Category.Name }}</td>
                    <td>{{ video.ReproducedTimes }}</td>
                    <td>
                        <video :src="video.Source" controls
                               width="250"
                               v-if="getVideos[video.Id]"
                               @play="onPlay(video)">
                            <p>If you are reading this, it is because your browser does not support the audio element.</p>
                        </video>
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
        name: 'table-video',
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
            this.videos.map(video => this.files[video.Id] = true, this);
        },
        computed: {
            videos() {
                return this.data;
            },
            getVideos() {
                return this.files;
            }
        },
        data() {
            return {
                files: {}
            }
        },
        methods: {
            async onPlay(video) {
                video.ReproducedTimes++;
                await api.mediaAddReproducedTime({mediaId: video.Id});
            }
        },
    }
</script>
<style>
</style>
