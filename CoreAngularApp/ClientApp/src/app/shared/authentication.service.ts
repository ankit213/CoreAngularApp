import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";

@Injectable()
export class AuthenticationService implements CanActivate {
  constructor(private router: Router) {

  }

  canActivate() {
    var token = localStorage.getItem("jwt");
    if (token) {
      return true;
    }
    this.router.navigate(["login"]);
    return false;
  }
}



  
