<template>
  <nav class="navbar navbar-expand-lg navBg">
    <div class="collapse navbar-collapse justify-content-between" id="navbarText">
      <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
        <div class="d-flex flex-column align-items-center">
          <h1 @click="travelHome" class="logo hoverable m-0">
            keepr
          </h1>
        </div>
      </router-link>
      <button
        class="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarText"
        aria-controls="navbarText"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon" />
      </button>
      <div class="navbar-nav">
        <div class="search-container">
        <form action="/action_page.php">
          <input type="text" placeholder="Search..." name="search">
          <button type="submit"><i class="fa fa-search"></i></button>
        </form>
      </div>
      </div>
      <span class="navbar-text">
        <button
          class="btn btn-outline-primary text-uppercase"
          @click="login"
          v-if="!user.isAuthenticated"
        >
          Login
        </button>

        <div class="dropdown" v-else>
          <div
            class="dropdown-toggle"
            @click="state.dropOpen = !state.dropOpen"
          >
          <button
            class="btn btn-outline-primary btnGrey">{{ user.name }}
          </button>
          </div>
          <div
            class="dropdown-menu p-0 list-group w-100"
            :class="{ show: state.dropOpen }"
            @click="state.dropOpen = false"
          >
            <router-link :to="{ name: 'Account' }">
              <div class="list-group-item list-group-item-action hoverable">
                Profile
              </div>
            </router-link>
            <div
              class="list-group-item list-group-item-action hoverable"
              @click="logout"
            >
              Logout
            </div>
          </div>
        </div>
      </span>
    </div>
  </nav>
</template>

<script>

import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
import { useRouter } from 'vue-router'
export default {
  name: 'Navbar',
  setup() {
    const state = reactive({
      dropOpen: false
    })
    const router = useRouter()
    const travelHome = () => { router.push('/') }
    return {
      state,
      travelHome,
      user: computed(() => AppState.user),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        await AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style scoped>

@font-face {
  font-family: "Pacifico";
  src: local("Pacifico"),
   url(../assets/font/Pacifico-Regular.ttf) format("truetype");
}

.logo{
  font-family: "Pacifico";
  color: rgb(0, 35, 36);
}

.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
}
.dropdown-menu.show {
  transform: scale(1);
}
.hoverable {
  cursor: pointer;
}
a:hover {
  text-decoration: none;
}
.nav-link{
  text-transform: uppercase;
}
.nav-item .nav-link.router-link-exact-active{
  color: var(--primary);
}

.navBg{
  background-color: turquoise;
}

.btnGrey{
  background-color: rgb(80, 80, 80);
  color: whitesmoke;
}
</style>
