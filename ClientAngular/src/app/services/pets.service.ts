import { Injectable } from '@angular/core';
import {Http,Response} from '@angular/http';
import 'rxjs/Rx';
import {Observable} from "rxjs/Observable";

@Injectable()
export class PetsService {
  baseUrl = 'http://localhost:59465';

  constructor(private http: Http) { }

  getBaseUrl() {
    return this.baseUrl;
  }

  getAllPets() {
    return this.http.get(this.baseUrl + '/api/pets').catch((error: Response | any)=>{
      console.log('Error Code: ' +error.status + ' Message: ' + error.statusText);
      return Observable.throw(error);
    });
  }
}
