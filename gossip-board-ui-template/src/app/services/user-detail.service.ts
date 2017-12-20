import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import {User} from "../models/user";

@Injectable()
export class UserDetailService {
  private readonly backendUrl = 'http://localhost:29270';
  private readonly webApiUrl = `${this.backendUrl}/api`;
  private readonly accountApiUrl = `${this.webApiUrl}/account`;
  private readonly userApiUrl = `${this.webApiUrl}/user`;
  private readonly registerApiUrl = `${this.accountApiUrl}/register`;
  private readonly loginApiUrl = `${this.accountApiUrl}/login`;
  private readonly logoutApiUrl = `${this.accountApiUrl}/logout`;
  private readonly isSignedInApiUrl = `${this.accountApiUrl}`;
  private readonly changePasswordApiUrl = `${this.userApiUrl}`;

  private get RequestOptions() {
    return {
      headers: new HttpHeaders().set('Content-Type', 'application/json'),
      withCredentials: true
    };
  }

  constructor(private http: HttpClient) { }

  getUser(): Observable<User> {
    return this.http.get<User>(this.userApiUrl, this.RequestOptions);
  }
}
