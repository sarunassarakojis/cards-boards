import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {PollPost} from '../../models/poll-post';
import {NgForm} from '@angular/forms';
import {PollItem} from '../../models/poll-item';

@Component({
  selector: 'app-poll-post-input',
  templateUrl: './poll-post-input.component.html',
  styleUrls: ['./poll-post-input.component.css']
})
export class PollPostInputComponent implements OnInit {

  @Input() buttonText: string;
  @Output() submitButtonClick = new EventEmitter<PollPost>();
  pollPost: PollPost = new PollPost();
  pollItems: PollItem[];

  constructor() {
    this.pollItems = [];
    for (let i = 0; i < 3; i++) {
      this.pollItems.push(new PollItem());
    }
  }

  ngOnInit() {
  }

  onButtonClick() {
    const pollPostToEmit = new PollPost();
    pollPostToEmit.postAuthor = this.pollPost.postAuthor;
    pollPostToEmit.subject = this.pollPost.subject;
    pollPostToEmit.description = this.pollPost.description;
    pollPostToEmit.pollItems = this.pollItems.filter(value => value.pollItemText != null);

    this.submitButtonClick.emit(pollPostToEmit);
  }

  onSubmit(form: NgForm) {
    form.resetForm();
  }
}
