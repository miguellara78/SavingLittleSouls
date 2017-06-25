import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import {DataHelperService} from "./data-helper.service";
import {RequestOptions} from "@angular/http";

@Injectable()
export class PetsService {
  private petsDataUrl = 'api/pets/';
  constructor(private dataHelperService: DataHelperService) {
  }

  getAllPets() {
    return this.dataHelperService.getData(this.petsDataUrl);
  }

  getPet(id: number) {
    return this.dataHelperService.getDataById(this.petsDataUrl + id);
  }

  postNewPet(pet: any){
    return this.dataHelperService.postData(this.petsDataUrl,pet);
  }

  postNewPetImage(image: File,petId: number){
    return this.dataHelperService.postImage(this.petsDataUrl + 'images/' + petId,image);
  }
}
