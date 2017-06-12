import { Component, OnInit } from '@angular/core';
import {PetsService} from "../services/pets.service";
import {DataHelperService} from "../services/data-helper.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./css/animate.css','./css/Grid.css','./css/latofonts.css','./css/main.css','./css/Site.css','./css/queries.css']
})
export class HomeComponent implements OnInit {
  pets: any[];
  baseURL: string;

  constructor(private petsService: PetsService,private dataHelperService: DataHelperService) {

  }

  ngOnInit() {
    this.baseURL = this.dataHelperService.getBaseUrl();
    this.petsService.getAllPets().subscribe((res) => {
      this.pets = res.json()
    });
  }
}
