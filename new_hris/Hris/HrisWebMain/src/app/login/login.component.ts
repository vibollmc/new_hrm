import { Component, AfterViewInit } from "@angular/core";

declare var $: any;

@Component({
  selector: "login",
  templateUrl: "./login.html"
})
export class LoginComponent implements AfterViewInit {
  ngAfterViewInit(): void {

    $("body").addClass("off-canvas-sidebar").addClass("login-page");

    setTimeout(() => {
        $(".card").removeClass("card-hidden");
      },
      700);
  }
}
