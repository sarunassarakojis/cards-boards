import {Component, OnInit} from '@angular/core';
import {PollPost} from '../../models/poll-post';
import {PollPostService} from '../../services/poll-post.service';
import {Router} from '@angular/router';
import {MdSnackBar} from '@angular/material';

@Component({
  selector: 'app-poll-post-list',
  templateUrl: './poll-post-list.component.html',
  styleUrls: ['./poll-post-list.component.css']
})
export class PollPostListComponent implements OnInit {

  pollPosts: PollPost[] = [];

  constructor(private pollPostService: PollPostService, private router: Router, public snackBar: MdSnackBar) {
  }

  ngOnInit() {
    this.pollPostService.getPollPosts().subscribe(pollPosts => {
      this.pollPosts = pollPosts;
      console.log(pollPosts);
    }, error => console.log(error));
  }

  addNewPollPost(pollPost: PollPost) {
    this.pollPostService.addPollPost(pollPost)
      .subscribe(poll => {
        pollPost = poll;
        this.pollPosts.push(pollPost);
        this.snackBar.open('You successfully created poll post', null, { duration: 3000});
      });
  }

}
