<template>
    <div>
        <div class="row">
            <div class="col-3"
                 style="cursor: pointer"
                 @click="onMediaSelected(1)">
                <stats-card-custom style="height: 50vh;background: rgb(55, 89, 239);">
                    <div slot="type">Musica</div>
                </stats-card-custom>
            </div>
            <div class="col-3"
                 style="cursor: pointer"
                 @click="onMediaSelected(2)">
                <stats-card-custom style="height: 50vh;background: rgb(0, 169, 69);">
                    <div slot="type">Videos</div>
                </stats-card-custom>
            </div>
            <div class="col-3"
                 style="cursor: pointer"
                 @click="onMediaSelected(3)">
                <stats-card-custom style="height: 50vh;background: rgb(248, 190, 41);">
                    <div slot="type">Libros</div>
                </stats-card-custom>

            </div>
            <div class="col-3"
                 style="cursor: pointer"
                 @click="onMediaSelected(4)">
                <stats-card-custom style="height: 50vh;background: rgb(223, 0, 70);">
                    <div slot="type">Imagenes</div>
                </stats-card-custom>
            </div>
        </div>
    </div>
</template>
<script>
    import store from "@/store/index";
    import StatsCardCustom from "../../components/StatsCardCustom";
    export default {
        components: {StatsCardCustom},
        methods: {
            onMediaSelected(id) {
                store.state.mediaTypeSelected = id;
                this.$router.push('albums');
            }
        }
    };
</script>
<style></style>
