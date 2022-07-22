import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';
import { Booking, Discount, FlightTrip, FlightTripDetails, FlightTripSearchResults, FlightTripSummary, Passenger, Schedule } from './passenger.model';

@Component({
  selector: 'app-passenger',
  templateUrl: './passenger.component.html',
})
export class PassengerComponent implements OnInit {


  constructor(private http: HttpClient, private _router: Router, private _auth: AuthService) { }

  results: FlightTripSearchResults = new FlightTripSearchResults();
  flightSummary: FlightTripSummary = new FlightTripSummary();
  flightTripModel: FlightTrip = new FlightTrip();
  scheduleModel: Schedule = new Schedule();
  scheduleModels: Array<Schedule> = new Array<Schedule>();
  seatType: string = '';
  passengerModel: Passenger = new Passenger();
  passengerModels: Array<Passenger> = new Array<Passenger>();
  noOnwardRecords: boolean = false;
  noReturnRecords: boolean = false;
  isSelected: boolean = false;
  bookingModel: Booking = new Booking();
  bookingModels: Array<Booking> = new Array<Booking>();
  seatNumber: Number = 0;
  onwardFlightChosen: Schedule = new Schedule;
  ReturnFlightChosen: Schedule = new Schedule;
  price: number = 0;
  showPassenger: boolean = false;
  round: boolean = false;
  discount:string='';
  finalPrice:number=0;
  discountModels:Array<Discount> = new Array<Discount>();

  ngOnInit(): void {
  }


  OnSelect(event: Event) {
    this.scheduleModel.flightId = Number((event.target as HTMLInputElement).value);
  }

  Toggle(event: Event) {
    this.flightTripModel.trip = (event.target as HTMLInputElement).value;
    if (this.flightTripModel.trip == "Oneway") {
      (document.getElementById("inputendDate") as HTMLInputElement).disabled = true;
      this.flightTripModel.returnDateTime = '';
    }
    else {
      (document.getElementById("inputendDate") as HTMLInputElement).disabled = false;
    }
  }

  FindFlights(flightTrip: FlightTrip) {
    if ((document.getElementById("Oneway") as HTMLInputElement).checked) {
      console.log(flightTrip);
      let onewayTrip = {
        trip: 'One way',
        sourcePlace: flightTrip.sourcePlace,
        destinationPlace: flightTrip.destinationPlace,
        startDateTime: new Date(flightTrip.startDateTime),
      };

      this.flightSummary.onwardTrip = onewayTrip;
      this.flightSummary.returnTrip = new FlightTripDetails();
    }
    else {
      let onewayTrip = {
        trip: 'Round Trip',
        sourcePlace: flightTrip.sourcePlace,
        destinationPlace: flightTrip.destinationPlace,
        startDateTime: new Date(flightTrip.startDateTime),
      }

      let returnModel = {
        trip: 'Round Trip',
        sourcePlace: flightTrip.destinationPlace,
        destinationPlace: flightTrip.sourcePlace,
        startDateTime: new Date(flightTrip.returnDateTime)
      }

      this.flightSummary.onwardTrip = onewayTrip;
      this.flightSummary.returnTrip = returnModel;
    }

    this.http.post("http://20.232.8.205/gateway/api/1.0/flight/search", this.flightSummary).subscribe(res => this.GetSchedulesFromServer(res), res => console.log(res));
    
  }

  GetSchedulesFromServer(res: any) {
    console.log(res);
    this.results = res;
    if (this.results.onwardFlightResults.length == 0) {
      this.noOnwardRecords = true;
    }
    else{
      this.noOnwardRecords = false;
    }

    if (((document.getElementById("Round") as HTMLInputElement).checked) && this.results.onwardFlightResults.length == 0) {
      this.noReturnRecords = true;
    }
    else{
      this.noReturnRecords = false;
    }
  }

  OnwardSelected(flight: any) {
    let index = this.results.onwardFlightResults.findIndex(x => x.isSelected);

    if (index >= 0) {
      this.results.onwardFlightResults[index].isSelected = false;
    }
    this.onwardFlightChosen = flight;
    this.isSelected = true;
    flight.isSelected = true;
  }

  ReturnSelected(flight: any) {
    let index = this.results.returnFlightResults.findIndex(x => x.isSelected);

    if (index >= 0) {
      this.results.returnFlightResults[index].isSelected = false;
    }
    this.ReturnFlightChosen = flight;
    this.isSelected = true;
    flight.isSelected = true;
  }

  ApplyCoupon()
  {
    this.http.get("http://20.232.8.205/gateway/api/1.0/flight/discount").subscribe(res => this.GetDiscountFromServer(res), res => console.log(res));
  }

  GetDiscountFromServer(res: any) {
    console.log(res);
    this.discountModels = res;
    if(this.discountModels.find(x=>x.discountCode == this.discount))
    {
      this.discountModels.forEach(element => {
        if(this.discount == element.discountCode)
        {
          this.finalPrice = (this.price * ((100-element.percentage)/100))
        }
      });
    }
    else
    {
      alert("Invalid Coupon");
    }
   
  }

  PassengerDetails() {
    this.seatNumber = Number(this.bookingModel.seatsToBook);
    this.price = Number(this.onwardFlightChosen.ticketPrice) * Number(this.bookingModel.seatsToBook);
    this.showPassenger = true;
    if ((document.getElementById("Round") as HTMLInputElement).checked) {
      this.price += Number(this.ReturnFlightChosen.ticketPrice) * Number(this.bookingModel.seatsToBook);
      this.round = true;
    }


    for (let i = 0; i < this.seatNumber; i++) {
      let passenger = new Passenger();
      passenger.index = i;
      this.passengerModels.push(passenger);
    }

    var user = this._auth.User();
    this.bookingModel.email = user!;
  }

  
  Calculate()
  {
    this.seatNumber = Number(this.bookingModel.seatsToBook);
    this.price = Number(this.onwardFlightChosen.ticketPrice) * Number(this.bookingModel.seatsToBook);
    this.finalPrice = this.price;
    if ((document.getElementById("Round") as HTMLInputElement).checked) {
      this.price += Number(this.ReturnFlightChosen.ticketPrice) * Number(this.bookingModel.seatsToBook);
      this.round = true;
    }
  }

  BookFlight(booking: Booking, passenger: Array<Passenger>) {
    var pass = new Array<Passenger>();
    for (let i = 0; i < this.seatNumber; i++) {
        let value : Passenger = new Passenger();
        value.passengerName = passenger[i].passengerName,
        value.passengerAge = Number(passenger[i].passengerAge) ,
        value.meal = passenger[i].meal,
        value.seat = passenger[i].seat,
        value.gender = passenger[i].gender,
        value.seatType = this.seatType,
        value.returnSeat = passenger[i].returnSeat,
        value.bookingId = Number(passenger[i].bookingId)

        pass.push(value);
    };

    var bookingdto = {
      customerName: booking.customerName,
      email: booking.email,
      seatsToBook: Number(booking.seatsToBook),
      flightId: this.onwardFlightChosen.flightId,
      startDateTime: new Date(this.onwardFlightChosen.startDateTime),
      fromPlace: this.onwardFlightChosen.fromPlace,
      toPlace: this.onwardFlightChosen.toPlace,
      price: Number(this.finalPrice != 0 ? this.finalPrice : this.price),
      trip: this.round ? "Round Trip " : "One Way",
      isCancelled : "No",
      passengers: pass
    }

    console.log(bookingdto);
    console.log(this.bookingModel);
    this.http.post("http://20.232.8.205/gateway/api/1.0/flight/booking", bookingdto).subscribe(res => this.GetBooking(), res => console.log(res));
    this.scheduleModel = new Schedule();
  }

  GetBooking() {
    this.http.get("http://20.232.8.205/gateway/api/1.0/flight/booking/bookedHistory").subscribe(res => this.GetFromServer(res), res => console.log(res));
  }

  GetFromServer(res: any) {
    console.log(res);
    this.bookingModels = res;
    alert("Ticket Booked Successfully \nPNR Number is " +  this.bookingModels[0].pnr);
    this._router.navigate(['/dashboard']);
  }

  Cancel()
  {
    this._router.navigate(['/dashboard']);
  }
}



