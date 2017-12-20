import { Component, OnInit } from '@angular/core';
import {UserService} from '../../services/user.service';
import {Router} from '@angular/router';
import {MdSnackBar} from '@angular/material';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private userService: UserService, private router: Router, public snackBar: MdSnackBar) { }

  ngOnInit() {
    this.userService.isSignedIn().subscribe((isSignedIn: boolean) => {
      if (!isSignedIn) {
        // console.log('Not logged in. Should redirect to /login');
        this.snackBar.open('You\'re not logged in. Redirecting to login page', null, { duration: 5000});
        this.router.navigate(['login']);
      }
    });

  }

}
