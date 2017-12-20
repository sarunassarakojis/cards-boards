import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {User} from '../../models/user';
import {NgForm} from '@angular/forms';
import {UserService} from '../../services/user.service';
import {Router} from '@angular/router';
import {MdButton, MdSnackBar} from '@angular/material';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  loginUser: User = new User();
  loginForm: NgForm;

  constructor(private userService: UserService, private router: Router, public snackBar: MdSnackBar) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    const userToEmit = new User();
    userToEmit.username = this.loginUser.username;
    userToEmit.password = this.loginUser.password;
    userToEmit.remember = this.loginUser.remember;
    this.loginForm = form;
    this.login(userToEmit);
  }

  login(user: User) {
    this.userService.login(user)
      .subscribe((loggedIn: boolean) => {
        if (loggedIn) {
          console.log('User successfully logged in');
          this.snackBar.open('You successfully logged in', null, { duration: 3000});
          this.loginForm.resetForm();
          this.router.navigate(['home']);
        } else {
          console.log('User not logged in');
          this.snackBar.open('Invalid username and/or password!', null, { duration: 3000});
        }
      });
  }

}
