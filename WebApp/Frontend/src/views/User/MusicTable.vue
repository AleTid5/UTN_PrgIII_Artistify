<template>
    <div class="card shadow"
         :class="type === 'dark' ? 'bg-default': ''">
        <div class="card-header border-0"
             :class="type === 'dark' ? 'bg-transparent': ''">
            <div class="row align-items-center">
                <div class="col">
                    <h3 class="mb-0" :class="type === 'dark' ? 'text-white': ''">
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
                <tr v-for="music in musics" :key="music.Id">
                    <th scope="row">
                        {{ music.Name }}
                    </th>
                    <td class="budget">
                        {{music.Rating}}
                    </td>
                    <td class="budget">
                        {{music.Gender.Name}}
                    </td>
                    <td>{{ music.Category.Name }}</td>
                    <td>{{ music.ReproducedTimes }}</td>
                    <td>
                        <aplayer autoplay
                                 :music="{ title: music.Name,
                                           artist: music.Album.Artist.Alias,
                                           src: music.Source,
                                           pic: ''
                                           }"
                        />
                    </td>
                </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
    import Aplayer from 'vue-aplayer'

    export default {
        name: 'music-table',
        components: {
            Aplayer
        },
        props: {
            type: {
                type: String
            },
            title: String,
            data: Array
        },
        computed: {
            musics() {
                console.log(this.data);
                return this.data;
            }
        },
        data() {
            return {

            }
        }
    }
</script>
<style>
</style>
