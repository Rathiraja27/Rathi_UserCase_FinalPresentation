import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { PassengerComponent } from './passenger.component';
import { Passengerroutes } from '../routing/passengerroutes';

@NgModule({
    declarations: [
        PassengerComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild(Passengerroutes),
        HttpClientModule,
    ],
    providers: [],
    bootstrap: [PassengerComponent]
})
export class PassengerModule { }