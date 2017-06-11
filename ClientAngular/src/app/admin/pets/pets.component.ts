import { Component, OnInit } from '@angular/core';
import {PetsService} from "../../services/pets.service";

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent implements OnInit {

  pets: any[];

  constructor(private petsService: PetsService) { }

  ngOnInit() {
    this.petsService.getAllPets().subscribe((res) => {
      this.pets = res.json()
    });
  }

}
