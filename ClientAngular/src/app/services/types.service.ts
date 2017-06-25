import { Injectable } from '@angular/core';
import {DataHelperService} from "./data-helper.service";

@Injectable()
export class TypesService {

  private typessDataUrl = 'api/animalTypes/';
  constructor(private dataHelperService: DataHelperService) {
  }

  getAllTypes() {
    return this.dataHelperService.getData(this.typessDataUrl);
  }

}
