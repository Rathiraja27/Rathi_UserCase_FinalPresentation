import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _registerUrl="http://20.232.8.205/gateway/api/1.0/flight/admin/register";
  private _loginUrl="http://20.232.8.205/gateway/api/1.0/flight/admin/login";

  constructor(private http:HttpClient,private _router:Router) { }

  loginUser(user:any)
  {
    return this.http.post<any>(this._loginUrl,user);
  }
  regsiterUser(user:any)
  {
    return this.http.post<any>(this._registerUrl,user);
  }
  logoutUser(){
    localStorage.removeItem('token');
    this._router.navigate(['/home']);
  }
  loggedIn(){
    return !!localStorage.getItem('token');
  }
  getToken(){
    return localStorage.getItem('token');
  }

  isAdmin()
  {
    var role = localStorage.getItem('Role')
    if(role=="Admin")
    {
       return true;
    }
    return false;
  }

  User()
  {
    var user = localStorage.getItem('User');
    return user;
  }

}