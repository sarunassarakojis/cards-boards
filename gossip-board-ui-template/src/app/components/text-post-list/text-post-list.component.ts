import {Component, OnInit} from '@angular/core';
import {TextPost} from '../../models/text-post';
import {TextPostService} from '../../services/text-post.service';
import {Router} from '@angular/router';
import {MdSnackBar} from '@angular/material';

@Component({
  selector: 'app-text-post-list',
  templateUrl: './text-post-list.component.html',
  styleUrls: ['./text-post-list.component.css']
})
export class TextPostListComponent implements OnInit {

  textPosts: TextPost[] = [];
  newTextPost: TextPost = new TextPost();

  constructor(private textPostService: TextPostService, private router: Router, public snackBar: MdSnackBar) {
  }

  ngOnInit() {
    this.textPostService.getTextPosts().subscribe(textPosts => {
        this.textPosts = textPosts;
        console.log(textPosts);
      },
      error => {
        console.log(error);
      });
  }

  addNewTextPost(textPost: TextPost) {
    this.textPostService.addTextPost(textPost)
      .subscribe((newTextPost: TextPost) => {
        textPost = newTextPost;
        this.textPosts.push(textPost);
        this.snackBar.open('You successfully created text post', null, {duration: 3000});
      });
  }

  onRemoveButtonClick(textPost: TextPost) {
    this.deleteFromList(this.textPosts, 'id', textPost.id);
    this.textPostService.deleteTextPost(textPost)
      .subscribe((result: boolean) => {
        this.snackBar.open('Card was deleted successfully', null, {duration: 3000});
      });
  }

  deleteFromList(arr, attr, value) {
    let i = arr.length;
    while (i--) {
      if (arr[i]
        && arr[i].hasOwnProperty(attr)
        && (arguments.length > 2 && arr[i][attr] === value)) {

        arr.splice(i, 1);

      }
    }
    return arr;
  }
}
