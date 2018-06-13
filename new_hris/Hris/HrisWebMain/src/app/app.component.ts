import { Component, AfterViewInit } from "@angular/core";
import { Router } from "@angular/router";
import { ShareModel } from "./shared/share.model";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html"
})
export class AppComponent implements AfterViewInit {

  constructor(public readonly sm: ShareModel,
    private readonly router: Router) {
  }

  ngAfterViewInit(): void {
  }

  logout() {
    this.sm.token = null;
    this.router.navigate(["login"]);
  }
}
