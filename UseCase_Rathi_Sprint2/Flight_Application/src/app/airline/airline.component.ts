import { getLocalePluralCase } from '@angular/common';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FLAG_UNRESTRICTED } from 'html2canvas/dist/types/css/syntax/tokenizer';
import { Airline } from './airline.model';

@Component({
  selector: 'app-airline',
  templateUrl: './airline.component.html',
})
export class AirlineComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.GetAirlines();
  }

  airlineModel: Airline = new Airline();
  airlineModels: Array<Airline> = new Array<Airline>();
  EditButton: boolean = false;
  add: boolean = false;
  selectedFile :any = null;
  file:string='';
  showLoading : boolean = false;

  GetAirlines() {
    this.http.get("https://localhost:44348/gateway/api/1.0/flight/airlines").subscribe(res => this.GetFromServer(res), res => console.log(res));
  }

  GetFromServer(res: any) {
    console.log(res);
    this.airlineModels = res;
  }

  DeleteAirline(airline: Airline) {
    console.log(airline);
    if (confirm("Are you sure you want to delete the Airline")) {
      let httparms = new HttpParams().set("Id", airline.airlineId);
      let options = { params: httparms };
      this.showLoading=true;
      this.http.delete("https://localhost:44348/gateway/api/1.0/flight/airlines", options).subscribe(res => { this.GetAirlines(); console.log(res) }, res => console.log(res));
      this.showLoading=false;
    }
  }

  GetUrl(res:any)
  {
    
    this.showLoading=false;
    console.log(res);
    this.file = res;
  }

  AddAirline(airline: Airline) {

    if(this.selectedFile != undefined)
    {
      const formData : FormData = new FormData();
      formData.set('formFile',this.selectedFile);
      console.log(formData);
      this.http.post('https://localhost:44348/gateway/api/Blob', formData).subscribe(res => this.GetUrl(res), res=> console.log(res));
    }
    if (this.EditButton) {
      this.airlineModel = airline;

      var airlinedto = {
        airlineId: this.airlineModel.airlineId,
        airlineName: this.airlineModel.airlineName,
        description: this.airlineModel.description,
        logo: this.file,
        phoneNumber: this.airlineModel.phoneNumber,
        address: this.airlineModel.address,
        airlineStatus: this.airlineModel.airlineStatus,
      }

      if ((event?.target as Element).id == "btnAdd") {
        this.EditDetails(airlinedto);
      }
    }
    else {
      var dto = {
        airlineId: this.airlineModel.airlineId,
        airlineName: this.airlineModel.airlineName,
        description: this.airlineModel.description,
        logo: this.file,
        phoneNumber: this.airlineModel.phoneNumber,
        address: this.airlineModel.address,
        airlineStatus: this.airlineModel.airlineStatus
      }

      console.log(dto);
      console.log(this.airlineModel);
      this.http.post("https://localhost:44348/gateway/api/1.0/flight/airline/register", dto).subscribe(res => this.GetAirlines(), res => console.log(res));
      this.airlineModel = new Airline();
      this.add = true;
    }
  }

  FetchLogo(file:any)
  {
    this.selectedFile = file.target.files[0];
  }



  EditDetails(airline: Airline) {
    this.http.put("https://localhost:44348/gateway/api/1.0/flight/airlines", airline).subscribe(res => this.GetAirlines(), res => console.log(res));
    this.airlineModel = new Airline();
    this.EditButton = false;
  }

  EditAirline(airline: Airline) {
    this.EditButton = true;
    this.AddAirline(airline);
  }
}
