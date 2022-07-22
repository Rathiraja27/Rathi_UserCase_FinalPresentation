import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthguardService {

  constructor(private _authService: AuthService, private _router: Router) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if (this._authService.loggedIn()) {
      if(!this._authService.isAdmin() && (state.url === "/airline/add" || state.url === "/schedule/add" 
       || state.url === "/airline" || state.url === "/schedule"))
      {
        alert('User is not authorised to access the url, Navigating to Home Page');
        this._router.navigate(['']);
        return false;
      }
      else{
        return true;
      }
    }
    else {
      this._router.navigate(['']);
      return false;
    }
  }
}
