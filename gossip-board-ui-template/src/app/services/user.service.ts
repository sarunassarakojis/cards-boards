import { Injectable } from '@angular/core';
import {User} from '../models/user';
import {Observable} from 'rxjs/Observable';
import {HttpHeaders, HttpClient} from '@angular/common/http';

@Injectable()
export class UserService {

  private readonly backendUrl = 'http://localhost:5000';
  private readonly webApiUrl = `${this.backendUrl}/api`;
  private readonly accountApiUrl = `${this.webApiUrl}/account`;
  private readonly userApiUrl = `${this.webApiUrl}/user`;
  private readonly registerApiUrl = `${this.accountApiUrl}/register`;
  private readonly loginApiUrl = `${this.accountApiUrl}/login`;
  private readonly logoutApiUrl = `${this.accountApiUrl}/logout`;
  private readonly isSignedInApiUrl = `${this.accountApiUrl}`;
  private readonly changePasswordApiUrl = `${this.userApiUrl}`;

  constructor(private http: HttpClient) { }

  private get RequestOptions() {
    return {
      headers: new HttpHeaders().set('Content-Type', 'application/json'),
      withCredentials: true
    };
  }

  register(user: User): Observable<boolean> {
    const body = JSON.stringify(user);
    return this.http.post(this.registerApiUrl, body, this.RequestOptions);
  }

  login(user: User): Observable<boolean> {
    const body = JSON.stringify(user);
    return this.http.post(this.loginApiUrl, body, this.RequestOptions);
  }

  logout(): Observable<boolean> {
    return this.http.post(this.logoutApiUrl, null, this.RequestOptions);
  }

  isSignedIn(): Observable<boolean> {
    return this.http.get(this.isSignedInApiUrl, this.RequestOptions);
  }

  changePassword(user: User): Observable<boolean> {
    const body = JSON.stringify(user);
    return this.http.post(this.changePasswordApiUrl, body, this.RequestOptions);
  }

}
