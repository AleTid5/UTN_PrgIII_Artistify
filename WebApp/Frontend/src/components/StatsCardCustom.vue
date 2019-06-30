<template>
  <card class="card-stats card card-block d-flex" :show-footer-line="true">
    <div class="row">
      <div class="card-body align-items-center d-flex justify-content-center text-uppercase text-white mt-7"
           style="padding: 1rem 0.5rem;">
        <div style="font-size: 2em;">
          <slot name="type"></slot>
        </div>
      </div>
    </div>
  </card>
</template>
<script>
  import Card from './Card.vue';

  export default {
    name: 'stats-card-custom',
    components: {
      Card
    },
    props: {
      type: {
        type: String,
        default: 'primary'
      },
      icon: String,
      title: String,
      subTitle: String,
      iconClasses: [String, Array]
    }
  };
</script>
<style></style>
