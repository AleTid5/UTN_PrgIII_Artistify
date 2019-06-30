<template>
    <div>
        <div class="row">
            <div class="col-3"
                 style="cursor: pointer"
                 @click="onMediaSelected(1)">
                <stats-card-custom style="height: 50vh;background-color: #5e72e4ed">
                    <div slot="type">
                        <base-button outline :rounded="true" type="primary">
                            <i class="fa fa-music"></i>
                        </base-button>
                    </div>
                </stats-card-custom>
            </div>
            <div class="col-3"
                 style="cursor: pointer"
                 @click="onMediaSelected(2)">
                <stats-card-custom style="height: 50vh;background-color: #2dce89ed">
                    <div slot="type">
                        <base-button outline :rounded="true" type="success">
                            <i class="fa fa-video"></i>
                        </base-button>
                    </div>
                </stats-card-custom>
            </div>
            <div class="col-3"
                 style="cursor: pointer"
                 @click="onMediaSelected(3)">
                <stats-card-custom style="height: 50vh;background-color: #fb6340ed">
                    <div slot="type">
                        <base-button outline :rounded="true" type="warning">
                            <i class="fa fa-book"></i>
                        </base-button>
                    </div>
                </stats-card-custom>

            </div>
            <div class="col-3"
                 style="cursor: pointer"
                 @click="onMediaSelected(4)">
                <stats-card-custom style="height: 50vh;background-color: #f5365ced">
                    <div slot="type">
                        <base-button outline :rounded="true" type="danger">
                            <i class="fa fa-image"></i>
                        </base-button>
                    </div>
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
<style scoped>
    >>> .rounded-circle {
        height: 10em;
        width: 10em;
    }

    >>> .btn.rounded-circle > i {
        line-height: 85px;
        margin-left: -6px;
        font-size: 90px;
    }
</style>
