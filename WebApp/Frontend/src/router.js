import Vue from 'vue'
import Router from 'vue-router'
import DashboardLayout from '@/layout/DashboardLayout'
import DashboardLayoutArtist from '@/layout/DashboardLayoutArtist'
import DashboardLayoutManager from '@/layout/DashboardLayoutManager'
import AuthLayout from '@/layout/AuthLayout'
import Store from '@/store/index.js'
Vue.use(Router);

const validateRouteUser = (to, from, next) => {
  Store.state.user && Store.state.userType === 1 ? next() : next('/');
};
const validateRouteArtist = (to, from, next) => {
  Store.state.user && Store.state.userType === 2 ? next() : next('/artist/login');
};
const validateRouteManager = (to, from, next) => {
  Store.state.user && Store.state.userType === 3 ? next() : next('/manager/login');
};

const route = new Router({
  linkExactActiveClass: 'active',
  routes: [
    {
      path: '/',
      redirect: 'login',
      component: AuthLayout,
      children: [
        {
          path: '/login',
          name: 'login',
          component: () => import('./views/User/Login.vue')
        },
        {
          path: '/register',
          name: 'register',
          component: () => import('./views/User/Register.vue')
        },
        {
          path: '/artist/login',
          name: 'login Artist',
          component: () => import('./views/Artist/Login.vue')
        },
        {
          path: '/manager/login',
          name: 'login Manager',
          component: () => import('./views/Manager/Login.vue')
        },
        {
          path: '/manager/register',
          name: 'register Manager',
          component: () => import('./views/Manager/Register.vue')
        }
      ]
    },
    {
      path: '/',
      redirect: 'dashboard',
      component: DashboardLayout,
      children: [
        {
          path: '/user/dashboard',
          name: 'dashboard',
          component: () => import('./views/User/Dashboard.vue'),
          beforeEnter: validateRouteUser
        },
        {
          path: '/user/albums',
          name: 'Albums',
          component: () => import('./views/User/Albums.vue'),
          beforeEnter: validateRouteUser
        },
        {
          path: '/user/albums/mediaContent',
          name: 'Media Content',
          component: () => import('./views/User/MediaContent.vue'),
          beforeEnter: validateRouteUser
        },
      ]
    },
    {
      path: '/',
      redirect: 'dashboard',
      component: DashboardLayoutArtist,
      children: [
        {
          path: '/artist/dashboard',
          name: 'dashboard Artist',
          component: () => import('./views/Artist/Dashboard.vue'),
          beforeEnter: validateRouteArtist
        },
      ]
    },
    {
      path: '/',
      redirect: 'dashboard',
      component: DashboardLayoutManager,
      children: [
        {
          path: '/manager/dashboard',
          name: 'Dashboard',
          component: () => import('./views/Manager/Dashboard.vue'),
          beforeEnter: validateRouteManager
        },
        {
          path: '/manager/artists',
          name: 'Lista de Artistas',
          component: () => import('./views/Manager/Artists/List.vue'),
          beforeEnter: validateRouteManager
        },
        {
          path: '/manager/artists/add',
          name: 'Agregar artista',
          component: () => import('./views/Manager/Artists/Add.vue'),
          beforeEnter: validateRouteManager
        },
        {
          path: '/manager/artists/edit/:artistId',
          name: 'Editar artista',
          component: () => import('./views/Manager/Artists/Edit.vue'),
          beforeEnter: validateRouteManager
        },
      ]
    }
  ]
});

export default route;
