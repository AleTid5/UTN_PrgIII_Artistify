import Vue from 'vue'
import Router from 'vue-router'
import DashboardLayout from '@/layout/DashboardLayout'
import AuthLayout from '@/layout/AuthLayout'
import Store from '@/store/index.js'
Vue.use(Router);

const validateRouteUser = (to, from, next) => {
  Store.state.user && Store.state.userType === 1 ? next() : next('/');
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
          component: () => import(/* webpackChunkName: "demo" */ './views/User/Login.vue')
        },
        {
          path: '/register',
          name: 'register',
          component: () => import(/* webpackChunkName: "demo" */ './views/User/Register.vue')
        },
        {
          path: '/artist/login',
          name: 'loginArtist',
          component: () => import(/* webpackChunkName: "demo" */ './views/Artist/Login.vue')
        },
        {
          path: '/manager/login',
          name: 'loginManager',
          component: () => import(/* webpackChunkName: "demo" */ './views/Manager/Login.vue')
        },
        {
          path: '/manager/register',
          name: 'loginManager',
          component: () => import(/* webpackChunkName: "demo" */ './views/Manager/Register.vue')
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
          name: 'dashboardUser',
          // route level code-splitting
          // this generates a separate chunk (about.[hash].js) for this route
          // which is lazy-loaded when the route is visited.
          component: () => import(/* webpackChunkName: "demo" */ './views/User/Dashboard.vue'),
          beforeEnter: validateRouteUser
        },
        {
          path: '/artist/dashboard',
          name: 'dashboardArtist',
          // route level code-splitting
          // this generates a separate chunk (about.[hash].js) for this route
          // which is lazy-loaded when the route is visited.
          component: () => import(/* webpackChunkName: "demo" */ './views/Artist/Dashboard.vue'),
          beforeEnter: validateRouteUser
        },
        {
          path: '/manager/dashboard',
          name: 'dashboardManager',
          // route level code-splitting
          // this generates a separate chunk (about.[hash].js) for this route
          // which is lazy-loaded when the route is visited.
          component: () => import(/* webpackChunkName: "demo" */ './views/Manager/Dashboard.vue'),
          beforeEnter: validateRouteUser
        },
        {
          path: '/icons',
          name: 'icons',
          component: () => import(/* webpackChunkName: "demo" */ './views/Icons.vue'),
          beforeEnter: validateRouteUser
        },
        {
          path: '/profile',
          name: 'profile',
          component: () => import(/* webpackChunkName: "demo" */ './views/UserProfile.vue'),
          beforeEnter: validateRouteUser
        },
        {
          path: '/maps',
          name: 'maps',
          component: () => import(/* webpackChunkName: "demo" */ './views/Maps.vue'),
          beforeEnter: validateRouteUser
        },
        {
          path: '/tables',
          name: 'tables',
          component: () => import(/* webpackChunkName: "demo" */ './views/Tables.vue'),
          beforeEnter: validateRouteUser
        }
      ]
    }
  ]
});

export default route;
