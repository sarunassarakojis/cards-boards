import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {TextPost} from '../../models/text-post';
import {TextPostService} from '../../services/text-post.service';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-text-post-input',
  templateUrl: './text-post-input.component.html',
  styleUrls: ['./text-post-input.component.css']
})
export class TextPostInputComponent implements OnInit {
  @Input() buttonText: string;
  @Input() textPost: TextPost;
  @Output() submitButtonClick = new EventEmitter<TextPost>();


  constructor(private textPostService: TextPostService) { }

  ngOnInit() {
  }

  onButtonClick() {
    const textPostToEmit = new TextPost();
    textPostToEmit.postAuthor = this.textPost.postAuthor;
    textPostToEmit.subject = this.textPost.subject;
    textPostToEmit.description = this.textPost.description;
    this.submitButtonClick.emit(textPostToEmit);
  }
  onSubmit(form: NgForm) {
    form.resetForm();
  }
}
