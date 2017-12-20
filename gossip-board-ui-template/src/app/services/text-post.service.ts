import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {TextPost} from '../models/text-post';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class TextPostService {

  private readonly backendUrl = 'http://localhost:5000';
  private readonly webApiUrl = `${this.backendUrl}/api`;
  private readonly textPostApiUrl = `${this.webApiUrl}/textPost`;
  private readonly likeTextPostApiUrl = `${this.textPostApiUrl}/like`;

  constructor(private http: HttpClient) { }

  getTextPosts(): Observable<TextPost[]> {
    return this.http.get<TextPost[]>(this.textPostApiUrl);
  }

  private get RequestOptions() {
    return {
      headers: new HttpHeaders().set('Content-Type', 'application/json'),
      withCredentials: true
    };
  }
  addTextPost(textPost: TextPost): Observable<TextPost> {
    const body = JSON.stringify(textPost);
    return this.http.post(this.textPostApiUrl, body, this.RequestOptions);
  }
  getTextPost(textPostId: string): Observable<TextPost> {
    return this.http.get<TextPost>(`${this.textPostApiUrl}/${textPostId}`);
  }
  updateTextPost(textPost: TextPost): Observable<TextPost> {
    const body = JSON.stringify(textPost);
    return this.http.put(this.textPostApiUrl, body, this.RequestOptions);
  }
  deleteTextPost(textPostId: TextPost): Observable<boolean> {
    return this.http.delete(`${this.textPostApiUrl}/${textPostId}`, this.RequestOptions);
  }
  likeTextPost(textPost: TextPost): Observable<TextPost> {
    const body = JSON.stringify(textPost);
    return this.http.post(this.likeTextPostApiUrl, body, this.RequestOptions);
  }
}
