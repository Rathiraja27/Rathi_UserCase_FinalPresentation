import { CommonModule, DatePipe } from '@angular/common';
import { NgModule } from '@angular/core';

import { RouterModule } from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BookingComponent } from './booking.component';
import { Bookingroutes } from '../routing/bookingroutes';
import { AuthService } from '../service/auth.service';

@NgModule({
    declarations: [
        BookingComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild(Bookingroutes),
        HttpClientModule
    ],
    providers: [AuthService, DatePipe],
    bootstrap: [BookingComponent]
})
export class BookingModule { }