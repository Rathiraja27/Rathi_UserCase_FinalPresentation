import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Schedule } from '../schedules/schedules.model';
import { Router } from '@angular/router';
import { Booking, Passenger } from './ticketbooking.model';
import { AuthService } from '../service/auth.service';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';

@Component({
  selector: 'app-ticketbooking',
  templateUrl: './ticketbooking.component.html',
})
export class TicketbookingComponent implements OnInit {

  constructor(private http: HttpClient, private _router: Router, private _auth: AuthService) { }
  ngOnInit(): void {
   this.GetBooking();
  }

  
  bookingModel: Booking = new Booking();
  bookingModels: Array<Booking> = new Array<Booking>();
  bookModels: Array<Booking> = new Array<Booking>();
  scheduleModel: Schedule = new Schedule();
  scheduleModels: Array<Schedule> = new Array<Schedule>();
  show: boolean = true;
  showError:boolean=false;

  GetBooking() {
    this.http.get("https://localhost:44348/gateway/api/1.0/flight/booking/bookedHistory").subscribe(res => this.GetFromServer(res), res => console.log(res));
  }

  GetFromServer(res: any) {
    if (this._auth.isAdmin()) {
      console.log(res);
      this.bookingModels = res;
    }
    else {
      var name = this._auth.User();
      this.bookModels = res;
      this.bookModels.forEach(element => {
        if (element.email == name) {
          this.bookingModels.push(element);
        }
      });
    }
  }

  modalHeader: string = '';
  modalText: string = '';

  LaunchModal(booking: Booking) {
    this.modalHeader = "Booking Details"
    this.modalText = "Customer Name - " + booking.customerName + " \nEmail - " + booking.email +
      "\nNumber of Seats - " + booking.seatsToBook;
    document.getElementById("modelButton")?.click()
  }

  Search(booking:Booking)
  {
    console.log(booking.pnr);
    let httparms = new HttpParams().set("pnr", booking.pnr);
    let options = { params: httparms };
    this.http.get("https://localhost:44348/gateway/api/1.0/flight/ticket", options).subscribe(res => this.GetBookingByPNR(res) , res => this.HandleError(res));

  }

  HandleError(res : any)
  {
    console.log(res);
    this.bookingModels=new Array<Booking>();
    this.showError = true;
  }

  GetBookingByPNR(res : any){
    this.bookingModels=new Array<Booking>();
    console.log(res);
    this.bookingModel = res;
    this.bookingModels.push(this.bookingModel);
    this.showError = false;
  }
}
