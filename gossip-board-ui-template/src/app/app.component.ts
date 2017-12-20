import { Component } from '@angular/core';
import {UserService} from './services/user.service';
import {Router} from '@angular/router';
import {MdSnackBar} from '@angular/material';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor(private userService: UserService, private router: Router, public snackBar: MdSnackBar) { }

  onProfileClick() {
    this.router.navigate(['user']);
  }

  onLoginClick() {
    this.router.navigate(['login']);
  }

  onRegisterClick() {
    this.router.navigate(['register']);
  }

  onLogoutClick() {
    this.userService.logout()
      .subscribe((loggedOut: boolean) => {
        if (loggedOut) {
          this.snackBar.open('You successfully logged out', null, { duration: 3000});
          this.router.navigate(['login']);
        } else {
          this.snackBar.open('Nothing to log out', null, { duration: 3000});
        }
      });
  }
}
