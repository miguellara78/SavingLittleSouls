import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import {DataHelperService} from "./data-helper.service";

@Injectable()
export class PetsService {
  private petsDataUrl = '/api/pets/';
  constructor(private dataHelperService: DataHelperService) {
  }

  getAllPets() {
    return this.dataHelperService.getData(this.petsDataUrl);
  }

  getPet(id: number) {
    return this.dataHelperService.getDataById(this.petsDataUrl + id);
  }
}
