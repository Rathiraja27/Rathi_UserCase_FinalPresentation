import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Schedule } from '../schedules/schedules.model';
import { AuthService } from '../service/auth.service';
import { Booking } from './booking.model';
import * as jspdf from 'jspdf'
import html2canvas from 'html2canvas';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
})
export class BookingComponent implements OnInit {

  constructor(private http: HttpClient, private _auth: AuthService, private datePipe: DatePipe) { }

  showSearch: boolean = false;
  ngOnInit(): void {
    this.GetBooking();
    if (this._auth.isAdmin()) {
      this.showSearch = true;
    }
  }

  bookingModel: Booking = new Booking();
  bookingModels: Array<Booking> = new Array<Booking>();
  bookModels: Array<Booking> = new Array<Booking>();
  scheduleModel: Schedule = new Schedule();
  scheduleModels: Array<Schedule> = new Array<Schedule>();
  showError:boolean=false;

  GetBooking() {
    this.http.get("https://localhost:44348/gateway/api/1.0/flight/booking/bookedHistory").subscribe(res => this.GetFromServer(res), res => console.log(res));
  }

  GetFromServer(res: any) {

    this.bookingModels = res;


    if (this._auth.isAdmin()) {
      console.log(res);
      this.bookingModels = res;
    }
    else {
      this.bookingModels = Array<Booking>();
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
      "\nNumber of Seats - " + booking.seatsToBook + "\nJourney Date - " + this.datePipe.transform(booking.startDateTime, "dd-MM-yyyy")
      + "\nSource - " + booking.fromPlace + "\nDestination - " + booking.toPlace;
    document.getElementById("modelButton")?.click()
  }

  Search(booking: Booking) {
    console.log(booking.email);
    let httparms = new HttpParams().set("email", booking.email);
    let options = { params: httparms };
    this.http.get("https://localhost:44348/gateway/api/1.0/flight/booking/history", options).subscribe(res => this.GetBookingByEmail(res) , res => this.HandleError(res));

  }

  HandleError(res : any)
  {
    console.log(res);
    this.bookingModels=new Array<Booking>();
    this.showError = true;
  }

  GetBookingByEmail(res : any){
    this.bookingModels=new Array<Booking>();
    console.log(res);
    this.bookingModels=res;
    this.showError = false;
  }

  Cancel(index: any) {
    if (confirm("Do you want to cancel the ticket?")) {
      console.log(index);
      for (let i = 0; i < this.bookingModels.length; i++) {
        console.log(this.bookingModels);
        console.log(this.bookingModels[index]);
        if (this.bookingModels[i].bookingId == this.bookingModels[index].bookingId) {
          console.log(this.bookingModels[i].pnr);
          let pnr = String(this.bookingModels[i].pnr);
          this.http.put("https://localhost:44348/gateway/api/1.0/flight/booking/cancel/"+ pnr, {} ).subscribe(res => this.GetBooking(), res => console.log(res));
        }
      }
    }
  }

  Download(booking: Booking) {
    let pdf = new jspdf.jsPDF();

    this.bookingModels.find(x => x.pnr == booking.pnr);
    let title = "FLIGHT TICKET";
    pdf.text("----------------------- ", 80, 33);
    pdf.text(title, 80, 30).setFontSize(11).setFont(title, 'bold');
    pdf.text("Email ", 30, 50);
    pdf.text(": " + booking.email, 90, 50);
    pdf.text("Customer Name  ", 30, 60);
    pdf.text(": " + booking.customerName, 90, 60);
    pdf.text("PNR ", 30, 70);
    pdf.text(": " + booking.pnr, 90, 70);
    pdf.text("Journey Date ", 30, 80);
    pdf.text(": " + this.datePipe.transform(booking.startDateTime, "dd-MM-yyyy"), 90, 80);
    pdf.text("Source ", 30, 90);
    pdf.text(": " + booking.fromPlace, 90, 90);
    pdf.text("Destination ", 30, 100);
    pdf.text(": " + booking.toPlace, 90, 100);
    pdf.text("Number of Passengers ", 30, 110);
    pdf.text(": " + booking.seatsToBook, 90, 110);
    if (booking.isCancelled == "Yes") {
      pdf.text("Ticket Cancelled ", 30, 120);
    }

    pdf.text("----------------------------------------------------------------------------------------------------------------------------- ", 30, 140);
    pdf.text("Passenger Name ", 30, 145);
    pdf.text("Passenger age ", 90, 145);
    pdf.text("Gender ", 150, 145);
    pdf.text("----------------------------------------------------------------------------------------------------------------------------- ", 30, 150);

    for (let i = 0; i < Number(booking.seatsToBook); i++) {
      pdf.text(booking.passengers[i].passengerName, 30, 152 + (7 * (i + 1)));
      pdf.text(booking.passengers[i].passengerAge.toString(), 100, 152 + (7 * (i + 1)));
      pdf.text(booking.passengers[i].gender.toString(), 150, 152 + (7 * (i + 1)));
      pdf.text("----------------------------------------------------------------------------------------------------------------------------- ", 30, 153 + (8 * (i + 1)));
    }


    pdf.text("------------------Wish you a Happy and Safe Journey------------------ ", 50, 280);


    pdf.save(booking.customerName + "_Ticket" + ".pdf");
    alert("Ticket Generated Successfully");
  }
}
