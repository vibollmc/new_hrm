import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

import { ShareService } from "../shared/share.service";
import { LoginService } from "./login.service";
import { Login } from "../shared/datamodel/login";
import { ResponseResult } from "../shared/datamodel/response.result";
import { NotificationProvider } from "../shared/notification.provider";


@Injectable()
export class LoginModel {
  objLogin: Login;
  message: string;

  constructor(
    private readonly loginService: LoginService,
    private readonly router: Router,
    private readonly shareService: ShareService,
    private readonly notification: NotificationProvider
  ) {
    if (this.shareService.token) this.router.navigate(["home"]);
    this.objLogin = new Login();
    this.message = null;
  }

  login() {
    this.loginService.login(this.objLogin)
      .subscribe(
        response => {
          var result = response.json() as ResponseResult;
          if (result.data) {
            this.objLogin.username = null;
            this.objLogin.password = null;

            this.shareService.token = result.data;
            this.router.navigate(["home"]);
          } else {
            this.notification.error("Đăng nhập không thành công. sai tên đăng nhập hoặc mật khẩu.");
          }
        },
        err => {
          this.notification.error(`Đăng nhập không thành công. Có lỗi xảy ra: ${err}`);
        });
  }
}
