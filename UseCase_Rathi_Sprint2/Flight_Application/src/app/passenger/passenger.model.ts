
export class FlightTrip{
    trip:string='';
    sourcePlace: string='';
    destinationPlace:string='';
    startDateTime:string='';
    returnDateTime:string='';
}

export class FlightTripDetails{
    trip:string='';
    sourcePlace: string='';
    destinationPlace:string='';
    startDateTime:Date=new Date();
}

export class FlightTripSummary{
    onwardTrip : FlightTripDetails=new FlightTripDetails();
    returnTrip : FlightTripDetails=new FlightTripDetails();
}

export class FlightTripSearchResults{
    onwardFlightResults : Array<Schedule> = new Array<Schedule>();
    returnFlightResults : Array<Schedule> = new Array<Schedule>();
}

export class Booking {
    bookingId:Number=0;
    customerName: string = '';
    email:string = '';
    seatsToBook:string = '';
    flightId:number = 0;
    bookedOn:string = '';
    startDateTime:string='';
    fromPlace:string='';
    toPlace:string='';
    price:Number=0;
    pnr:string='';
    trip:string='';
    passengers:Array<Passenger>=new Array<Passenger>();
}

export class Passenger {
    index:number=0;
    passengerId:number=0;
    passengerName: string = '';
    passengerAge:number = 0;
    meal:string = '';
    seat:string = '';
    bookingId:Number = 0;
    gender:string='';
    seatType:string='';
    returnSeat:string='';
}

export class Discount {
    discountCode:string='';
    percentage:number=0;
}

export class Schedule {
    flightId:number=0;
    flightName: string = '';
    instrumentUsed:string = '';
    airlineId:string = '';
    fromPlace:string = '';
    toPlace:string = '';
    startDateTime:string='';
    endDateTime:string='';
    sceduledDays:string='';
    businessClassSeats:string='';
    nonBusinessClassSeats:string='';
    ticketPrice:string='';
    rows:string='';
    meal:string='';
    isSelected : boolean = false;
    isCancelled : string ='';
} 
