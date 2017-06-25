import { Injectable } from '@angular/core';
import {DataHelperService} from "./data-helper.service";

@Injectable()
export class GendersService {

  private gendersDataUrl = 'api/genders/';
  constructor(private dataHelperService: DataHelperService) {
  }

  getAllGenders() {
    return this.dataHelperService.getData(this.gendersDataUrl);
  }
}
