import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Http = require("@angular/http");
import { Observable } from 'rxjs/Observable';
import { Router, ActivatedRoute } from '@angular/router';

var id;

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html'
})
export class DetailDataComponent {
  public doctorDetails: IDoctorDetail;
  myAppUrl: string = "";
  idValue: number =0;


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private _avRoute: ActivatedRoute) {
    this.myAppUrl = baseUrl;
    if (this._avRoute.snapshot.params["id"]) {
      this.idValue = this._avRoute.snapshot.params["id"];
    }
    this.http.get<IDoctorDetail>(this.myAppUrl + 'api/Doctors/'+this.idValue).subscribe(result => {

      this.doctorDetails = result;
    }, error => console.error(error));
  }

  

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}

interface IDoctorDetail {
  id: number;
  name: string;
  spokenLanguage: string;
  medicalSchoolAttended: string;
  patientReviews: string;
  isSuperStar: boolean,
}
