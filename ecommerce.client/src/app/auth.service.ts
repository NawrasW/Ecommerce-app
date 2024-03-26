import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserForLogin, UserLogin } from './models/auth';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import * as alertifyjs from 'alertifyjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { PayLoad } from './models/payload';
import { BehaviorSubject } from 'rxjs';
import { AlertService } from './alert.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _httpClient: HttpClient, private alert: AlertService, private router: Router) {

    this.userPayLoad = this.decodedToken();

  }
  url: string = "https://localhost:7033/api/auth";
  userPayLoad: PayLoad;
  //login
  authUser(user: UserForLogin): Observable<UserLogin> {
    return this._httpClient.post<UserLogin>(`${this.url}/login`, user);
  }
  logOut() {
    localStorage.clear();
    this.alert.success("login successfully")
    this.router.navigateByUrl('/user/login')
  }

  storeId(idvalue: number) {
    localStorage.setItem('id', idvalue.toString());
  }

  getUserId() {
    return localStorage.getItem('id');
  }


  storeToken(tokenValue: string) {
    localStorage.setItem('token', tokenValue);
  }
  getToken() {
    return localStorage.getItem('token');
  }
  isLogged(): boolean {
    const token = localStorage.getItem('token');
    const userId = localStorage.getItem('id');
    return !!userId && !!token;
  }
  storeFullName(fullName: string) {
    localStorage.setItem('fullName', fullName);
  }

  getFullName() {
    return localStorage.getItem('fullName');
  }


  storeEmail(email: string) {
    localStorage.setItem('email', email);
  }

  getEmail() {
    return localStorage.getItem('email');
  }





  decodedToken() {
    const jwtHelper = new JwtHelperService();
    const token = this.getToken();
    if (token)
      return jwtHelper.decodeToken(token);
  }
}
