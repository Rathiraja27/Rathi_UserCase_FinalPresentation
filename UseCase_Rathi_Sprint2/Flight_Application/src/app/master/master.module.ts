import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { MasterComponent } from './master.component';
import { RouterModule } from '@angular/router';
import { Mainroutes } from '../routing/mainroutes';
import { HomeComponent } from '../home/home.component';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';
import { AuthService } from '../service/auth.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptorService } from '../service/token-interceptor.service';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { DatePipe } from '@angular/common';
import { AuthguardService } from '../service/authguard.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    HomeComponent,
    MasterComponent,
    LoginComponent,
    RegisterComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(Mainroutes),
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule,
  ],
  providers: [AuthguardService, AuthService, { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true }, DatePipe],
  bootstrap: [MasterComponent]
})
export class MasterModule { }
