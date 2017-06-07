import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import {RoutesModule} from "./routes.module";
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { LoginComponent } from './login/login.component';
import { ErrorComponent } from './error/error.component';
import {PetsService} from "./services/pets.service";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AdminComponent,
    LoginComponent,
    ErrorComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RoutesModule
  ],
  providers: [PetsService],
  bootstrap: [AppComponent]
})

export class AppModule { }
