import { Injectable } from '@angular/core';
import {Http,Headers, RequestOptions} from "@angular/http";
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

  postData(dataUrl: string, bodyData: any){
    return this.http.post(this.baseUrl + dataUrl, bodyData).catch((error: Response | any) => {
      console.log('Error Code: ' +error.status + ' Message: ' + error.statusText);
      return Observable.throw(error);
    })
  }

  postImage(dataUrl: string, filesData: File[]){
    let formData: FormData = new FormData();
    filesData.forEach((data)=>{
      formData.append(data.name,data,data.name);
    });
    let headers = new Headers();
    let options = new RequestOptions({headers: headers});

    return this.http.post(this.baseUrl + dataUrl ,formData,options)
  }
}
