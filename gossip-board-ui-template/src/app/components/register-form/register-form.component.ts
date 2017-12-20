import {Component, OnInit} from '@angular/core';
import {UserService} from '../../services/user.service';
import {User} from '../../models/user';
import {FormControl, FormGroup, NgForm, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {MdSnackBar} from '@angular/material';

function passwordMatchValidator(g: FormGroup) {
  return g.get('password').value === g.get('confirmPassword').value
    ? null : {'mismatch': true};
}

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})

export class RegisterFormComponent implements OnInit {
  registerUser: User = new User();
  registerForm: FormGroup;
  regForm: NgForm;


  constructor(private userService: UserService, private router: Router, public snackBar: MdSnackBar) { }

  ngOnInit() {
    this.registerForm = new FormGroup({
      'email': new FormControl(this.registerUser.email, [
        Validators.required,
        Validators.email
      ]),
      'username': new FormControl(this.registerUser.username, [
        Validators.required
      ]),
      'password': new FormControl(this.registerUser.password, [
        Validators.required
      ]),
      'confirmPassword': new FormControl(this.registerUser.confirmPassword, [
        Validators.required
      ])
    }, passwordMatchValidator);
  }

  onSubmit(form: NgForm) {
    const userToEmit = new User();
    userToEmit.email = this.registerUser.email;
    userToEmit.username = this.registerUser.username;
    userToEmit.password = this.registerUser.password;
    userToEmit.confirmPassword = this.registerUser.confirmPassword;
    this.registerNewUser(userToEmit);
    this.regForm = form;
  }

  registerNewUser(user: User) {
    this.userService.register(user)
      .subscribe((registered: boolean) => {
        if (registered) {
          console.log('User successfully registered');
          this.snackBar.open('You successfully registered,\n Now log in', null, { duration: 3000});
          this.regForm.resetForm();
          this.router.navigate(['login']);
        } else {
          console.log('User not registered');
          this.snackBar.open('Registration error', null, { duration: 5000});
        }
      });
  }

  get email() { return this.registerForm.get('email'); }

  get username() { return this.registerForm.get('username'); }

  get password() { return this.registerForm.get('password'); }

}
