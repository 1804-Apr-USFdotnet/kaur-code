import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { AppRoutingModule } from './/app-routing.module';
import { PokemonComponent } from './pokemon/pokemon.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";

// ng new AngularApp
// cd AngularApp
// npm install
// ng generate component NavigationBar
// ng generate module app-routing--flat--module = app
// ng generate component Pokemon
// ng generate service Pokemon

@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    PokemonComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
