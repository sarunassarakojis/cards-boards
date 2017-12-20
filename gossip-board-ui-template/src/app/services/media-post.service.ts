import { Injectable } from '@angular/core';
import {HttpClient, HttpEvent, HttpHeaders, HttpRequest} from '@angular/common/http';
import {MediaPost} from '../models/media-post';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class MediaPostService {
  private readonly backendUrl = 'http://localhost:5000';
  private readonly webApiUrl = `${this.backendUrl}/api`;
  private readonly mediaPostApiUrl = `${this.webApiUrl}/mediaPost`;
  private readonly fileUploadUrl = `${this.webApiUrl}/fileUpload`;
  private readonly imagesUrl = `${this.backendUrl}/images`;
  constructor(private http: HttpClient) { }

  getMediaPosts(): Observable<MediaPost[]> {
    return this.http.get<MediaPost[]>(this.mediaPostApiUrl);
  }

  private get RequestOptions() {
    return {
      headers: new HttpHeaders().set('Content-Type', 'application/json'),
      withCredentials: true
    };
  }
  addMediaPost(mediaPost: MediaPost): Observable<MediaPost> {
    const body = JSON.stringify(mediaPost);
    return this.http.post(this.mediaPostApiUrl, body, this.RequestOptions);
  }
  getMediaPost(mediaPostId: string): Observable<MediaPost> {
    return this.http.get<MediaPost>(`${this.mediaPostApiUrl}/${mediaPostId}`);
  }
  updateMediaPost(mediaPost: MediaPost): Observable<MediaPost> {
    const body = JSON.stringify(mediaPost);
    return this.http.put(this.mediaPostApiUrl, body, this.RequestOptions);
  }
  deleteMediaPost(mediaPost: MediaPost): Observable<boolean> {
    const url = `${this.mediaPostApiUrl}/${mediaPost.id}`;
    console.log(url);
    return this.http.delete(url);
  }
  uploadFile(file: File): Observable<HttpEvent<any>> {
    const formData = new FormData();
    formData.append('files', file);

    const req = new HttpRequest('POST', this.fileUploadUrl, formData, {reportProgress: true});
    return this.http.request(req);
  }
  getMediaImageUrl(bareImageUrl: string) {
    return `${this.imagesUrl}/${bareImageUrl}`;
  }
}
