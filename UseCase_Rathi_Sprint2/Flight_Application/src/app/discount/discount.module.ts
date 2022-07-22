import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RouterModule } from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { DiscountComponent } from './discount.component';
import { Discountroutes } from '../routing/discountroutes';

@NgModule({
    declarations: [
        DiscountComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild(Discountroutes),
        HttpClientModule
    ],
    providers: [],
    bootstrap: [DiscountComponent]
})
export class DiscountModule { }