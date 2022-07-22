// export class Booking {
//     bookingId:number=0;
//     customerName: string = '';
//     email:string = '';
//     seatsToBook:string = '';
//     flightId:number = 0;
//     bookedOn:string = '';
//     startDateTime:string='';
//     fromPlace:string='';
//     toPlace:string='';
//     price:Number=0;
//     pnr:string='';
//     trip:string='';
// }

// export class Passenger {
//     index:number=0;
//     passengerId:number=0;
//     passengerName: string = '';
//     passengerAge:number = 0;
//     meal:string = '';
//     seat:string = '';
//     bookingId:Number = 0;
//     gender:string='';
//     seatType:string='';
//     returnSeat:string='';
// }

export class Booking {
    bookingId:number=0;
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
    cancelDuration:Number=0;
    isCancelled:string='';
    passengers:Array<Passenger>=new Array<Passenger>();
}


export class Passenger {
    index:number=0;
    passengerId:number=0;
    passengerName: string = '';
    passengerAge:string = '';
    meal:string = '';
    seat:number = 0;
    bookingId:string = '';
    gender:string='';
    seatType:string='';
    returnSeat:string='';
}
