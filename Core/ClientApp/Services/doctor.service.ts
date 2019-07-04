import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

export class DoctorService {
  myAppUrl: string = "";

  constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }
  getDoctors() {
    return this._http.get(this.myAppUrl + 'api/Doctor/Index')
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }
  getDoctorById(id: number) {
    return this._http.get(this.myAppUrl + "api/Doctor/Details/" + id)
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }
  
  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}
