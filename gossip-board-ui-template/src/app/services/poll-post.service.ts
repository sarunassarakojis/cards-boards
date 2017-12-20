import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import {PollPost} from '../models/poll-post';

@Injectable()
export class PollPostService {

  private readonly backendUrl = 'http://localhost:5000';
  private readonly webApiUrl = `${this.backendUrl}/api`;
  private readonly pollPostApiUrl = `${this.webApiUrl}/pollPost`;

  constructor(private http: HttpClient) {
  }

  getPollPosts(): Observable<PollPost[]> {
    return this.http.get<PollPost[]>(this.pollPostApiUrl);
  }

  addPollPost(pollPost: PollPost): Observable<PollPost> {
    const body = JSON.stringify(pollPost);

    return this.http.post(this.pollPostApiUrl, body, this.requestOptions);
  }

  private get requestOptions() {
    return {
      headers: new HttpHeaders().set('Content-Type', 'application/json'),
      withCredentials: true
    };
  }

}
