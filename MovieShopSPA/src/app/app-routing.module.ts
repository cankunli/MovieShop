import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { HomeComponent } from './home/home/home.component';
import { MovieCardListComponent } from './movies/movie-card-list/movie-card-list.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { CastComponent } from './shared/components/cast/cast.component';

const routes: Routes =
  [

    { path: "", component: HomeComponent },
    { path: "Movies/genre/:id", component: MovieCardListComponent },
    { path: "movies/:id", component: MovieDetailsComponent },
    { path: "movies/cast/:id", component: CastComponent},
    { path: "login", component:LoginComponent},
    { path: "register", component:RegisterComponent}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
