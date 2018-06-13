import { Component, AfterViewInit } from "@angular/core";

import { LoginModel } from "./login.model";
import { LoginService } from "./login.service";

declare var $: any;

@Component({
  selector: "login",
  providers: [
    LoginModel,
    LoginService
  ],
  templateUrl: "./login.html"
})
export class LoginComponent implements AfterViewInit {

  constructor(public readonly vm: LoginModel) {
    
  }

  login() {
    this.vm.login();
  }

  ngAfterViewInit(): void {

    $("body").addClass("off-canvas-sidebar").addClass("login-page");

    setTimeout(() => {
        $(".card").removeClass("card-hidden");
      },
      700);
  }
}
