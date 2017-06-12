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
import { PetsComponent } from './admin/pets/pets.component';
import { AdoptersComponent } from './admin/adopters/adopters.component';
import { BreedsComponent } from './admin/breeds/breeds.component';
import { TypesComponent } from './admin/types/types.component';
import { StatesComponent } from './admin/states/states.component';
import { GendersComponent } from './admin/genders/genders.component';
import { PetComponent } from './admin/pet/pet.component';
import { NewPetComponent } from './admin/new-pet/new-pet.component';
import { AdoptersService } from './services/adopters.service';
import { BreedsService } from './services/breeds.service';
import { GendersService } from './services/genders.service';
import { StatesService } from './services/states.service';
import { TypesService } from './services/types.service';
import { DataHelperService } from './services/data-helper.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AdminComponent,
    LoginComponent,
    ErrorComponent,
    PetsComponent,
    AdoptersComponent,
    BreedsComponent,
    TypesComponent,
    StatesComponent,
    GendersComponent,
    PetComponent,
    NewPetComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RoutesModule
  ],
  providers: [PetsService, AdoptersService, BreedsService, GendersService, StatesService, TypesService, DataHelperService],
  bootstrap: [AppComponent]
})

export class AppModule { }
