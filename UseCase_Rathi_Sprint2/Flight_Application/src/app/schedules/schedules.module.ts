import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RouterModule } from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import { SchedulesComponent } from './schedules.component';
import { Scheduleroutes } from '../routing/scheduleroutes';
import { FormsModule } from '@angular/forms';
import { AuthguardService } from '../service/authguard.service';

@NgModule({
    declarations: [
        SchedulesComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild(Scheduleroutes),
        HttpClientModule,
        
    ],
    providers: [AuthguardService],
    bootstrap: [SchedulesComponent]
})
export class ScheduleModule { }