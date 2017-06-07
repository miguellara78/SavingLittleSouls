import { Injectable } from '@angular/core';
import {Http} from "@angular/http";
import 'rxjs/Rx';

@Injectable()
export class PetsService {
  baseUrl: string = 'http://localhost:59465';

  constructor(private http: Http) { }

  getBaseUrl(){
    return this.baseUrl;
  }

  getAllPets() {
    return this.http.get(this.baseUrl + '/api/pets')
      .map((res)=>{
        return res.json() || []
      });
  }
}
