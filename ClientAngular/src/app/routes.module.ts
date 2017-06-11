import { NgModule } from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {HomeComponent} from "./home/home.component";
import {AdminComponent} from "./admin/admin.component";
import {LoginComponent} from "./login/login.component";
import {ErrorComponent} from "./error/error.component";
import {AdoptersComponent} from "./admin/adopters/adopters.component";
import {GendersComponent} from "./admin/genders/genders.component";
import {BreedsComponent} from "./admin/breeds/breeds.component";
import {PetsComponent} from "./admin/pets/pets.component";
import {StatesComponent} from "./admin/states/states.component";
import {TypesComponent} from "./admin/types/types.component";
import {PetComponent} from "app/admin/pet/pet.component";
import {NewPetComponent} from "./admin/new-pet/new-pet.component";

const routes: Routes = [
  {path: '', component: HomeComponent,pathMatch: 'full'},
  {path: 'admin', component: AdminComponent,children:[
    {path: 'adopters', component: AdoptersComponent},
    {path: 'genders', component: GendersComponent},
    {path: 'breeds', component: BreedsComponent},
    {path: 'pets', component: PetsComponent},
    {path: 'pets/new', component: NewPetComponent},
    {path: 'pets/:id', component: PetComponent},
    {path: 'states', component: StatesComponent},
    {path: 'types', component: TypesComponent},
  ]},
  {path: 'login', component: LoginComponent},
  {path: '**', component: ErrorComponent}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class RoutesModule { }
