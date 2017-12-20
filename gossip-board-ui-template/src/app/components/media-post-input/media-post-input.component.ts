import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {MediaPost} from '../../models/media-post';
import {MediaPostService} from '../../services/media-post.service';
import {NgForm} from '@angular/forms';
import {HttpEventType, HttpResponse} from '@angular/common/http';
import {FileUploadResult} from '../../models/file-upload-result';
import {ImagePath} from '../../models/image-path';
import { DomSanitizer, SafeResourceUrl, SafeUrl } from '@angular/platform-browser';
import {delay} from "q";
import {$} from "protractor";

@Component({
  selector: 'app-media-post-input',
  templateUrl: './media-post-input.component.html',
  styleUrls: ['./media-post-input.component.css']
})
export class MediaPostInputComponent implements OnInit {
  @Input() buttonText: string;
  @Input() mediaPost: MediaPost;
  @Output() submitButtonClick = new EventEmitter<MediaPost>();

  private image: File;

  constructor(private mediaPostService: MediaPostService, private sanitizer: DomSanitizer) {
  }

  ngOnInit() {
    this.mediaPost.imageUrls = new Array<ImagePath>();
  }
  onButtonClick() {
    const mediaPostToEmit = new MediaPost();
    let stringYou;
    if (this.mediaPost.videoUrl != null) {
      if (this.mediaPost.videoUrl.indexOf('=') == null) {
        stringYou = this.mediaPost.videoUrl;
      } else {
        stringYou = this.mediaPost.videoUrl.substring(this.mediaPost.videoUrl.indexOf('=') + 1);
      }
      this.mediaPost.videoUrl = 'http://www.youtube.com/embed/';
      this.mediaPost.videoUrl = this.mediaPost.videoUrl.concat(stringYou);
    }
    mediaPostToEmit.postAuthor = this.mediaPost.postAuthor;
    mediaPostToEmit.subject = this.mediaPost.subject;
    mediaPostToEmit.description = this.mediaPost.description;
    mediaPostToEmit.videoUrl = this.mediaPost.videoUrl;
    mediaPostToEmit.imageUrls = this.mediaPost.imageUrls;
    this.submitButtonClick.emit(mediaPostToEmit);
  }
  onSubmit(form: NgForm) {
    form.resetForm();
    this.image = null;
  }
  onFileChange(event) {
    const files = event.srcElement.files;
    if (files != null) {
      this.image = files[0];
      console.log(this.image);
      this.uploadImage();
      document.getElementById('uploadMessage').innerText = this.image.name + ' succesfully uploaded.';
    }
  }
  uploadImage() {
    if (this.image === null) {
      return;
    }
    this.mediaPostService.uploadFile(this.image).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress) {
        const percentDone = Math.round(100 * event.loaded / event.total);
        console.log(`File is ${percentDone}% uploaded.`);
      } else if (event instanceof HttpResponse) {
        if (event.ok) {
          console.log('File is completely uploaded!');
          console.log(event.body);
          const uploadResult = event.body as FileUploadResult;
          /*Neveikia kazkodel*/
          const imagePath = new ImagePath();
          imagePath.path = uploadResult.fileName;
          console.log('Image path: ' + imagePath.path);
          this.mediaPost.imageUrls.push(imagePath);
          console.log('Media post ilgis, jei ne 0 tai pavyko: ' + this.mediaPost.imageUrls.length);
          // this.mediaPost.imageUrls[0].path = uploadResult.fileName;

        } else {
          console.log('File upload failed!');
        }
      }
    });
  }
}
