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
                <th>Veces descargado</th>
                <th></th>
                </thead>
                <tbody>
                <tr v-for="book in books" :key="book.Id">
                    <th scope="row">
                        {{ book.Name }}
                    </th>
                    <td class="budget">
                        {{book.Rating}}
                    </td>
                    <td class="budget">
                        {{book.Gender.Name}}
                    </td>
                    <td>{{ book.Category.Name }}</td>
                    <td>{{ book.ReproducedTimes }}</td>
                    <td>
                        <base-button type="primary" icon="ni ni-bag-17" @click="onPlay(book)">With icon</base-button>
                    </td>
                </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
    import api from "@/api";

    export default {
        name: 'table-book',
        props: {
            type: {
                type: String
            },
            title: String,
            data: Array
        },
        beforeUpdate() {
            this.books.map(book => this.files[book.Id] = true, this);
        },
        computed: {
            books() {
                return this.data;
            },
            getBooks() {
                return this.files;
            }
        },
        data() {
            return {
                files: {}
            }
        },
        methods: {
            async onPlay(book) {
                this.download(book);
                book.ReproducedTimes++;
                await api.mediaAddReproducedTime({mediaId: book.Id});
            },
            download(book){
                const link = document.createElement('a');
                link.href = book.Source;
                link.setAttribute('download', book.Name + '.pdf');
                document.body.appendChild(link);
                link.click();
            },
        },
    }
</script>
<style>
</style>
