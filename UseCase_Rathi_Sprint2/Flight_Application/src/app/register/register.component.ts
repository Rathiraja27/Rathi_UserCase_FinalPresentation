import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { loginViewModel } from '../models/loginViewModel';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {
 
  constructor(private _auth: AuthService, private _router: Router) { }

  ngOnInit(): void {
  }
  registerModel : loginViewModel = new loginViewModel();
  showMessage : boolean=false;
  Register() {
    let register = {
      userName : this.registerModel.userName,
      password : this.registerModel.password,
      role:this.registerModel.role
    }
    this._auth.regsiterUser(register).subscribe(res => {
      this._router.navigate(['register']);
      this.showMessage=true;
      this.registerModel = new loginViewModel();
    },res => { console.log(res),this.showMessage=false});
  }

  hasError(typeofvalidator:string,controlname:string):Boolean{
    return this.registerModel.formCustomerGroup.controls[controlname].hasError(typeofvalidator);
  }
}
