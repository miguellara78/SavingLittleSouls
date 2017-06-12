import { Component, OnInit } from '@angular/core';
import {PetsService} from "../../services/pets.service";
import {ActivatedRoute, Params} from "@angular/router";
import {DataHelperService} from "../../services/data-helper.service";

@Component({
  selector: 'app-pet',
  templateUrl: './pet.component.html',
  styleUrls: ['./pet.component.css']
})
export class PetComponent implements OnInit {
  pet: any = {};
  baseUrl: string = '';
  petId: number;
  editMode = false;
  constructor(private petsService: PetsService,private dataHelperService: DataHelperService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.petId = this.route.snapshot.params['id'];
    this.baseUrl = this.dataHelperService.getBaseUrl();
    this.petsService.getPet(this.petId).subscribe((res) => {
      this.pet = res.json()[0];
    });
  }

  setEditMode(){
    this.editMode = true;
    console.log('Entering edit mode');
  }

  cancelEditMode(){
    this.editMode = false;
    this.petsService.getPet(this.petId).subscribe((res) => {
      this.pet = res.json()[0];
    });
  }

  saveChanges(){

  }

  deleteRecord(){

  }
}
