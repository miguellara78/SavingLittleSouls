import { Injectable } from '@angular/core';
import {Http} from "@angular/http";
import {Observable} from "rxjs/Observable";

@Injectable()
export class DataHelperService {

 private baseUrl = 'http://localhost:60676/';

  constructor(private http: Http) { }

  getBaseUrl() {
    return this.baseUrl;
  }

  getData(dataUrl: string){
    return this.http.get(this.baseUrl + dataUrl).catch((error: Response | any)=>{
      console.log('Error Code: ' +error.status + ' Message: ' + error.statusText);
      return Observable.throw(error);
    });
  }

  getDataById(dataUrl: string){
    return this.http.get(this.baseUrl + dataUrl).catch((error: Response | any)=>{
      console.log('Error Code: ' +error.status + ' Message: ' + error.statusText);
      return Observable.throw(error);
    });
  }
}
