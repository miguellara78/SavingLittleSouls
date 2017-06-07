import { Component, OnInit } from '@angular/core';
import {PetsService} from "../services/pets.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./css/animate.css','./css/font-awesome.css','./css/Grid.css','./css/latofonts.css','./css/main.css','./css/Site.css','./css/queries.css']
})
export class HomeComponent implements OnInit {
  pets: any = [];
  baseURL: string;

  constructor(private petsService: PetsService) {

  }

  ngOnInit() {
    this.baseURL = this.petsService.getBaseUrl();
    this.pets = this.petsService.getAllPets().subscribe((pets)=>{
      console.log(pets);
      this.pets = pets;
    });
  }
}
