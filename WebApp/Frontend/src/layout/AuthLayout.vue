<template>
    <div class="main-content bg-artistify">
        <!-- Navbar -->
        <base-nav class="navbar-top navbar-horizontal navbar-dark"
                  containerClasses="container"
                  expand>
            <span slot="brand"></span>

            <template v-slot="{closeMenu}">
                <!-- Collapse header -->
                <div class="navbar-collapse-header d-md-none">
                    <div class="row">
                        <div class="col-6 collapse-brand">
                            <router-link to="/">
                                <img src="img/brand/green.png">
                            </router-link>
                        </div>
                        <div class="col-6 collapse-close">
                            <button type="button"
                                    @click="closeMenu"
                                    class="navbar-toggler"
                                    aria-label="Toggle sidenav">
                                <span></span>
                                <span></span>
                            </button>
                        </div>
                    </div>
                </div>
                <!-- Navbar items -->
                <!--<ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <router-link class="nav-link nav-link-icon" to="/">
                            <i class="ni ni-planet"></i>
                            <span class="nav-link-inner&#45;&#45;text">Dashboard</span>
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link nav-link-icon" to="/register">
                            <i class="ni ni-circle-08"></i>
                            <span class="nav-link-inner&#45;&#45;text">Register</span>
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link nav-link-icon" to="/login">
                            <i class="ni ni-key-25"></i>
                            <span class="nav-link-inner&#45;&#45;text">Login</span>
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link nav-link-icon" to="/profile">
                            <i class="ni ni-single-02"></i>
                            <span class="nav-link-inner&#45;&#45;text">Profile</span>
                        </router-link>
                    </li>
                </ul>-->
            </template>
        </base-nav>
        <!-- Header -->
        <div class="header bg-gradient-success py-7">
        </div>
        <!-- Page content -->
        <div class="container mt--8 pb-5">
            <slide-y-up-transition mode="out-in" origin="center top">
                <router-view></router-view>
            </slide-y-up-transition>
        </div>
        <footer>
            <div class="container">
                <div class="row align-items-center justify-content-xl-between">
                    <div class="col-xl-6">
                        <div class="copyright text-center text-xl-left text-success">
                            &copy; {{year}} <a href="#" class="font-weight-bold ml-1 text-success" target="_blank">Artistify</a>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    </div>
</template>
<script>
    import { SlideYUpTransition } from 'vue2-transitions';
    import store from '@/store/index';

    export default {
        name: 'auth-layout',
        components: {
            SlideYUpTransition
        },
        created() {
            store.state.user = null;
            store.state.userType = null;
        },
        data() {
            return {
                year: new Date().getFullYear(),
                showMenu: false
            }
        }
    }
</script>
<style>
    html {
        background-color: #181413;
    }
</style>
