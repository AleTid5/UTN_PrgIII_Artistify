<template>
    <div>
        <base-header type="gradient-success" class="pb-6 pb-8 pt-5 pt-md-8">
            <!-- Card stats -->
            <div class="row">
                <div class="col-xl-3 col-lg-6"
                     style="cursor: pointer"
                     @click="onMediaSelected(1)">
                    <stats-card title=""
                                type="gradient-red"
                                sub-title="Música"
                                icon="fa fa-music"
                                class="mb-4 mb-xl-0"
                    >
                    </stats-card>
                </div>
                <div class="col-xl-3 col-lg-6"
                     style="cursor: pointer"
                     @click="onMediaSelected(2)">
                    <stats-card title=""
                                type="gradient-orange"
                                sub-title="Videos"
                                icon="fa fa-video"
                                class="mb-4 mb-xl-0"
                    >
                    </stats-card>
                </div>
                <div class="col-xl-3 col-lg-6"
                     style="cursor: pointer"
                     @click="onMediaSelected(3)">
                    <stats-card title=""
                                type="gradient-green"
                                sub-title="Libros"
                                icon="fa fa-book"
                                class="mb-4 mb-xl-0"
                    >
                    </stats-card>

                </div>
                <div class="col-xl-3 col-lg-6"
                     style="cursor: pointer"
                     @click="onMediaSelected(4)">
                    <stats-card title=""
                                type="gradient-info"
                                sub-title="Imágenes"
                                icon="fa fa-camera"
                                class="mb-4 mb-xl-0"
                    >
                    </stats-card>
                </div>
            </div>
        </base-header>
    </div>
</template>
<script>
    import store from "@/store/index";
    export default {
        data() {
            return {
            };
        },
        methods: {
            onMediaSelected(id) {
                store.state.mediaTypeSelected = id;
                this.$router.push('albums');
            }
        },
        mounted() {

        }
    };
</script>
<style></style>
