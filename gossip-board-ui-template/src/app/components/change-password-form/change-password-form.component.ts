import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, NgForm, Validators} from '@angular/forms';
import {User} from '../../models/user';
import {UserService} from '../../services/user.service';
import {MdSnackBar} from '@angular/material';

function passwordMatchValidator(g: FormGroup) {
  return g.get('password').value === g.get('confirmPassword').value
    ? null : {'mismatch': true};
}

@Component({
  selector: 'app-change-password-form',
  templateUrl: './change-password-form.component.html',
  styleUrls: ['./change-password-form.component.css']
})
export class ChangePasswordFormComponent implements OnInit {
  changePasswordUser: User = new User();
  changePasswordForm: FormGroup;
  changeForm: NgForm;

  constructor(private userService: UserService, public snackBar: MdSnackBar) { }

  ngOnInit() {
    this.changePasswordForm = new FormGroup({
      'oldPassword': new FormControl(this.changePasswordUser.oldPassword, [
        Validators.required
      ]),
      'password': new FormControl(this.changePasswordUser.password, [
        Validators.required
      ]),
      'confirmPassword': new FormControl(this.changePasswordUser.confirmPassword, [
        Validators.required
      ])
    }, passwordMatchValidator);
  }

  onSubmit(form: NgForm) {
    const userToEmit = new User();
    userToEmit.oldPassword = this.changePasswordUser.oldPassword;
    userToEmit.password = this.changePasswordUser.password;
    userToEmit.confirmPassword = this.changePasswordUser.confirmPassword;
    this.changePassword(userToEmit);
    this.changeForm = form;
  }

  changePassword(user: User) {
    this.userService.changePassword(user)
      .subscribe((changed: boolean) => {
        if (changed) {
          console.log('Password successfully changed');
          this.snackBar.open('You successfully changed your password', null, { duration: 3000});
          this.changeForm.resetForm();
        } else {
          console.log('Password not changed');
          this.snackBar.open('Password change error', null, { duration: 5000});
        }
      });
  }

}
