import { Component } from '@angular/core';
import { ApplicationUserModel } from '../applicationuser.model';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'register.component.html',
  styleUrls: ['register.component.scss']
})
export class RegisterComponent {

  userModel: ApplicationUserModel;
  isEmailExist: boolean;
  constructor(private accountService: AccountService, private router: Router) {
    this.userModel = new ApplicationUserModel();
    this.isEmailExist = false;
  }

  addUser() {
    this.accountService.registerUser(this.userModel).then((result) => {
      if (result.IsSuccess) {
        this.router.navigate(['login']);
      }
      else {

      }
    }, err => {
    });
  }

}
