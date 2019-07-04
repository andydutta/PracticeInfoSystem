import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Http = require("@angular/http");
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})

export class FetchDataComponent {
  public doctorsInfo: IDoctorsInfo[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IDoctorsInfo[]>(baseUrl + 'api/Doctors/AllDoctors').subscribe(result => {

      this.doctorsInfo = result;
    }, error => console.error(error));
  }
}

interface IDoctorsInfo {
  id: number;
  name: string;
  gender: string;
  specialties: string,
  averagePatientRating: string,
  isSuperStar: boolean,
  //temperatureF: number;
  //summary: string;
}
