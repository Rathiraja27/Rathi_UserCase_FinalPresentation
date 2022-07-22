import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { TicketbookingComponent } from './ticketbooking.component';
import { Ticketbookingroutes } from '../routing/ticketbookingroutes';

@NgModule({
    declarations: [
        TicketbookingComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild(Ticketbookingroutes),
        HttpClientModule,
    ],
    providers: [],
    bootstrap: [TicketbookingComponent]
})
export class TicketbookingModule { }