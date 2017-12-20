import { Component, OnInit } from '@angular/core';
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

  constructor(private textPostService: TextPostService, private router: Router, public snackBar: MdSnackBar) { }

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
        this.snackBar.open('You successfully created text post', null, { duration: 3000});
      });
  }
  onLikeClick(textPost: TextPost) {
    this.textPostService.likeTextPost(textPost)
      .subscribe((updatedTextPost: TextPost) => {
        console.log(updatedTextPost);
      });
  }
}
