import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

import { LocalStorage } from "../shared/local.storage";
import { LoginService } from "./login.service";
import { Login } from "../shared/datamodel/login";
import { ResponseResult } from "../shared/datamodel/response.result";
import { NotificationProvider } from "../shared/notification.provider";
import { Md5 } from "../shared/md5";

@Injectable()
export class LoginModel {
  objLogin: Login;
  message: string;

  constructor(
    private readonly loginService: LoginService,
    private readonly router: Router,
    private readonly localStorage: LocalStorage,
    private readonly notification: NotificationProvider
  ) {
    if (this.localStorage.token) this.router.navigate(["home"]);
    this.objLogin = new Login();
    //For test
    this.objLogin.username = "admin";
    this.objLogin.password = "admin";
    
    this.message = null;
  }

  login() {
    this.objLogin.password = Md5(this.objLogin.password);

    this.loginService.login(this.objLogin)
      .subscribe(
        response => {
          var result = response.json() as ResponseResult;
          this.objLogin.password = null;
          if (result.data) {
            this.objLogin.username = null;

            this.localStorage.token = result.data;
            this.router.navigate(["home"]);
          } else {
            this.notification.error("Đăng nhập không thành công. sai tên đăng nhập hoặc mật khẩu.");

          }
        },
        err => {
          this.objLogin.password = null;
          this.notification.error("Đăng nhập không thành công. sai tên đăng nhập hoặc mật khẩu.");
        });
  }
}
