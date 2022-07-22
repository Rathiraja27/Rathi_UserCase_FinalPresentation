import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { loginViewModel } from '../models/loginViewModel';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  loginModel : loginViewModel = new loginViewModel();
  constructor(private _auth: AuthService, private _router: Router) { }
  showMenu : boolean = false;
  showErrorMessage: boolean=false;
  ngOnInit(): void {
  }
  Login() { 
    let login = {
      userName : this.loginModel.userName,
      password : this.loginModel.password
    }
    this._auth.loginUser(login).subscribe(res => {
      localStorage.setItem('token', res.token);
      localStorage.setItem('Role', res.role);
      localStorage.setItem('User', res.user);
      this._router.navigate(['/dashboard']);
      this.showErrorMessage=false;
    }, res => { console.log(res), this.showErrorMessage=true});
  }

  hasError(typeofvalidator:string,controlname:string):Boolean{
    return this.loginModel.formCustomerGroup.controls[controlname].hasError(typeofvalidator);
  }
}
