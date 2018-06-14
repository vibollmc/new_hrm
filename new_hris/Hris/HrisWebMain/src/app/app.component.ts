import { Component, AfterViewInit } from "@angular/core";
import { Router } from "@angular/router";
import { ShareModel } from "./shared/share.model";
import { NotificationProvider } from "./shared/notification.provider";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html"
})
export class AppComponent implements AfterViewInit {

  constructor(public readonly sm: ShareModel,
    private readonly router: Router,
    private readonly notification: NotificationProvider) {
  }

  ngAfterViewInit(): void {
  }

  logout() {
    this.notification.confirm("Bạn muốn thoát khỏi hệ thống", "Xác nhận", (result) => {
      if (result) {
        this.sm.token = null;
        this.router.navigate(["login"]);    
      }
    });
  }
}
