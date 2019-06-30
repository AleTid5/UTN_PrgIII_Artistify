<template>
    <base-alert type="danger" dismissible style="position:fixed;top: 25px; right: 25px;z-index: 1" v-if="hasError">
        <span class="alert-inner--icon"><i class="fa fa-exclamation-circle"></i></span>
        <span class="alert-inner--text"><strong> Error!</strong> {{ message }}</span>
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </base-alert>
</template>
<script>
    export default {
        name: 'message-error',
        props: {
            hasError: {
                type: Boolean,
                default: false
            },
            message: null
        }
    }
</script>