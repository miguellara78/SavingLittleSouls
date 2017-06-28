import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {Router} from "@angular/router";
import {PetsService} from "../../../services/pets.service";
import {GendersService} from "../../../services/genders.service";
import {BreedsService} from "../../../services/breeds.service";
import {TypesService} from "../../../services/types.service";
import {isNullOrUndefined} from "util";

@Component({
  selector: 'app-new-pet',
  templateUrl: './new-pet.component.html',
  styleUrls: ['./new-pet.component.css']
})
export class NewPetComponent implements OnInit {
  private pet;
  private genders;
  private animalTypes;
  private breeds;
  @ViewChild('image1') image1: ElementRef;
  @ViewChild('image2') image2: ElementRef;
  @ViewChild('image3') image3: ElementRef;

  constructor(private router: Router,private petService: PetsService,private gendersService: GendersService,
    private breedsService: BreedsService,private animalTypesService: TypesService) { }

  ngOnInit() {
    this.pet = {name: '',age: '',weight: '', animalTypeId: '', genderId: '',breedId: '',color: '', notes: ''}
    this.gendersService.getAllGenders().subscribe((res) => {
      this.genders = res.json()
    });
    this.animalTypesService.getAllTypes().subscribe((res) => {
      this.animalTypes = res.json()
    });
    this.breedsService.getAllBreeds().subscribe((res) => {
      this.breeds = res.json()
    });
  }

  registerPet(){
    let images: File[] = [];
    let file = <HTMLInputElement>this.image1.nativeElement;
    if(file.files.length > 0){
      images.push(file.files[0]);
    }
    file = <HTMLInputElement>this.image2.nativeElement;
    if(file.files.length > 0){
      images.push(file.files[0]);
    }
    file = <HTMLInputElement>this.image3.nativeElement;
    if(file.files.length > 0){
      images.push(file.files[0]);
    }

    if( images.length > 0){
      this.petService.postNewPet(this.pet).subscribe((res) => {
        let newPet = res.json();
        this.petService.postNewPetImage(images,newPet.petId).subscribe((res2)=>{
          this.router.navigate(['admin/pets/' + newPet.petId]);
        });
      });
    }
  }

  cancelRegistration(){
    this.router.navigate(['admin/pets']);
  }
}
