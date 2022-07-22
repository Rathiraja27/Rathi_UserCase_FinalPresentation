import { Component, OnInit } from '@angular/core';
import { Schedule } from './schedules.model';
import { HttpClient } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { Airline } from '../airline/airline.model';

@Component({
  selector: 'app-schedules',
  templateUrl: './schedules.component.html',
})
export class SchedulesComponent implements OnInit {

  constructor(private http: HttpClient, private datePipe: DatePipe) { }

  ngOnInit(): void {
    this.GetSchedules();
    this.GetAirlines();
  }

  scheduleModel : Schedule = new Schedule();
  scheduleModels: Array<Schedule> = new Array<Schedule>();
  add : Boolean = false;

  ViewDetails(schedule : Schedule){
    this.scheduleModel = schedule;
  }

  airlineModel : Airline = new Airline();
  airlineModels: Array<Airline> = new Array<Airline>();
  airline: Array<Airline> = new Array<Airline>();
  EditButton : boolean = false;

  GetAirlines(){
    this.http.get("http://20.232.8.205/gateway/api/1.0/flight/airlines").subscribe(res => this.GetAirlinesFromServer(res), res => console.log(res));
  }

  GetAirlinesFromServer(res: any) {
    console.log(res);
    this.airline = res;
    for(let i=0; i<this.airline.length;i++)
    {
      if(this.airline[i].airlineStatus == 'Active')
      {
        this.airlineModels.push(this.airline[i]);
      }
    }
  }

  GetSchedules(){
    this.http.get("https://localhost:44348/gateway/api/1.0/flight/schedules").subscribe(res => this.GetFromServer(res), res => console.log(res));
  }

  OnSelect(event : Event)
  {
    this.scheduleModel.airlineId = (event.target as HTMLInputElement).value;
  }

  modalHeader : string ='';
  modalText : string ='';

  GetFromServer(res: any) {
    console.log(res);
    this.scheduleModels = res;
  }

  AddInventory() {
      var scheduledto = {
        flightName : this.scheduleModel.flightName,
        instrumentUsed: this.scheduleModel.instrumentUsed,
        airlineId: Number(this.scheduleModel.airlineId),
        fromPlace: this.scheduleModel.fromPlace,
        toPlace:this.scheduleModel.toPlace,
        startDateTime: new Date(this.scheduleModel.startDateTime),
        endDateTime: new Date(this.scheduleModel.endDateTime),
        sceduledDays:this.scheduleModel.sceduledDays,
        businessClassSeats:Number(this.scheduleModel.businessClassSeats),
        nonBusinessClassSeats:Number(this.scheduleModel.nonBusinessClassSeats),
        ticketPrice:Number(this.scheduleModel.ticketPrice),
        rows:Number(this.scheduleModel.rows),
        meal:this.scheduleModel.meal,
      }

      console.log(scheduledto);
      console.log(this.scheduleModel);
      this.http.post("http://20.232.8.205/gateway/api/1.0/flight/airline/inventory/add", scheduledto).subscribe(res => { this.GetSchedules(); console.log(res) }, res => console.log(res));
      this.scheduleModel = new Schedule();
      this.add = true;
    }

    LaunchModal(schedule :Schedule){
      this.modalHeader = "Schedule Details"
      this.modalText = "Source - " + schedule.fromPlace + " \nDestination - " + schedule.toPlace + 
      "\nFlight Name - " + schedule.flightName + " \nPrice- " + schedule.ticketPrice +
      "\nMeal - " + schedule.meal ;
      document.getElementById("modelButton")?.click()
  }

    selectedState= '';
	  onSelected(value:string): void {
		this.selectedState = value;

    
	}
}

