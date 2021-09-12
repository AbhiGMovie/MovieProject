import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BackButtonDirective } from './backbutton'

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ShowMoviesComponent } from './show-movies/show-movies.component';
import { ShowAllMoviesComponent } from './show-all/show-all.component';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ShowMoviesComponent,
    ShowAllMoviesComponent,    
    BackButtonDirective,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: ShowAllMoviesComponent, pathMatch: 'full' },
      { path: 'show-movies/:id', component: ShowMoviesComponent },      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
