<template>
    <div class="row">
        <div class="col-2" v-for="n in 5" :key="n">
            <i class="fa fa-star"
               style="cursor: pointer;"
               @click="setRating(n)"
               :class="{'text-warning': n === selectedRating}"></i>
        </div>
        <div class="col-2">
            <small>({{rating}})</small>
        </div>
    </div>
</template>

<script>
    import api from '@/api';
    import store from '@/store/index';

    export default {
        name: 'rating',
        props: {
            mediaId: Number,
            rating: Number
        },
        data() {
            return {
                selectedRating: 0
            }
        },
        created() {
          this.fillData();
        },
        methods: {
            async setRating(rating) {
                this.selectedRating = rating;

                await api.setUserMediaRating({
                    mediaId: this.mediaId,
                    userId: store.state.user.Id,
                    rating: rating
                });

                this.$emit('change');
            },

            async fillData() {
                const response = await api.getUserMediaRating(store.state.user.Id, this.mediaId);

                if (! response.Status) {
                    // ToDo: Error..
                    return;
                }

                this.selectedRating = response.Data;
            }
        },

        watch: {
            mediaId() {
                this.fillData();
            }
        }
    };
</script>
