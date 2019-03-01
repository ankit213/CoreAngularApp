import { Injectable } from "@angular/core";
import { Http, Headers } from "@angular/http";
import { AccountModel } from "../account/account.model";
import { ApplicationUserModel } from '../account/applicationuser.model';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';


@Injectable()
export class AccountService {
  private acountUrl = 'api/account';
  private headers = new Headers({ 'Content-Type': 'application/json' })
  constructor(private http: Http) {

  }


  login(model: AccountModel) {
    return this.http.post(this.acountUrl + '/login', JSON.stringify(model), { headers: this.headers })
      .map(res => res.json())
      .toPromise();
  }

  registerUser(newUser: ApplicationUserModel) {
    newUser.IsActive = true;
    return this.http.post(this.acountUrl, JSON.stringify(newUser), { headers: this.headers })
      .map(res => res.json())
      .toPromise();
  }

  logOut() {
    return this.http.get(this.acountUrl + '/logOut')
      .map(res => res.json())
      .toPromise();
  }
}



