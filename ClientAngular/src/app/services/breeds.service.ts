import { Injectable } from '@angular/core';
import {DataHelperService} from "./data-helper.service";

@Injectable()
export class BreedsService {

  private breedsDataUrl = 'api/breeds/';
  constructor(private dataHelperService: DataHelperService) {
  }

  getAllBreeds() {
    return this.dataHelperService.getData(this.breedsDataUrl);
  }

}
