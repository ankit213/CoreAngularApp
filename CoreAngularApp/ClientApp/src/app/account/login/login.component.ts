import { Component } from '@angular/core';
import { AccountService } from '../account.service';
import { AccountModel } from '../account.model';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'login.component.html'
})
export class LoginComponent {
  loginModel: AccountModel;
  errorMessage: string;
  constructor(private accountService: AccountService, private router: Router) {
    this.errorMessage = "";
    this.loginModel = new AccountModel();
  }

  login() {
    this.errorMessage = "";
    this.accountService.login(this.loginModel).then(result => {
      if (result != null) {
        if (result.Status == 1) {
          localStorage.setItem("jwt", result.AccessToken);
          this.router.navigate(['dashboard']);
        }
        else if (result.Status == 3) {
          this.errorMessage = result.Message;
        }
      }
    }).catch(err => {
    })
  }
}
