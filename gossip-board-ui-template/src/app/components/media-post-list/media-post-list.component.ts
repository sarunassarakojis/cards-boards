import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {MediaPost} from '../../models/media-post';
import {MediaPostService} from '../../services/media-post.service';
import {Router} from '@angular/router';
import {ImagePath} from '../../models/image-path';
import {DomSanitizer, SafeResourceUrl} from '@angular/platform-browser';
import {MdSnackBar} from '@angular/material';
import {UserDetailService} from '../../services/user-detail.service';
import {User} from '../../models/user';
import {error} from 'selenium-webdriver';
import UnableToSetCookieError = error.UnableToSetCookieError;

@Component({
  selector: 'app-media-post-list',
  templateUrl: './media-post-list.component.html',
  styleUrls: ['./media-post-list.component.css']
})
export class MediaPostListComponent implements OnInit {
  mediaPosts: MediaPost[] = [];
  newMediaPost: MediaPost = new MediaPost();
  userDetails: User = new User();
  @Output() deleteButtonClick = new EventEmitter<number>();
  videoUrl: SafeResourceUrl;
  constructor(private mediaPostService: MediaPostService, private router: Router, private sanitizer: DomSanitizer,
              public snackBar: MdSnackBar, private userDetailService: UserDetailService) { }

  getImageUrl(imagePath: ImagePath) {
    return this.mediaPostService.getMediaImageUrl(imagePath.path);
  }

  getSafeUrl(unsafeUrl: string) {
    this.videoUrl = this.sanitizer.bypassSecurityTrustResourceUrl(unsafeUrl);
    return this.videoUrl;
  }
  getUsername() {
    this.userDetailService.getUser().subscribe(userDetails => {
        this.userDetails.username = userDetails.username;
        console.log(userDetails.username);
      },
      error => {
        console.log(error);
      });
  }
  ngOnInit() {
    this.mediaPostService.getMediaPosts().subscribe(mediaPosts => {
        this.mediaPosts = mediaPosts;
        console.log(mediaPosts);
        this.getUsername();
      },
      error => {
        console.log(error);
      });
  }

  onDeleteButtonClick(deleteMediaPost: MediaPost) {
    this.mediaPostService.deleteMediaPost(deleteMediaPost).subscribe();
    this.deleteFromList(this.mediaPosts, 'id', deleteMediaPost.id);
  }

  deleteFromList(arr, attr, value){
    let i = arr.length;
    while ( i--) {
      if ( arr[i]
        && arr[i].hasOwnProperty(attr)
        && (arguments.length > 2 && arr[i][attr] === value ) ){

        arr.splice(i, 1);

      }
    }
    return arr;
  }

  addNewMediaPost(mediaPost: MediaPost) {
    this.mediaPostService.addMediaPost(mediaPost)
      .subscribe((newMediaPost: MediaPost) => {
        mediaPost = newMediaPost;
        this.mediaPosts.push(mediaPost);
        this.snackBar.open('You successfully created media post', null, { duration: 3000});
      });
  }
}
