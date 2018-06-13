import { Injectable } from "@angular/core";

import { BaseService } from "../shared/base.service";
import { HttpClient } from "../shared/http.client";
import { Login } from "../shared/datamodel/login";

@Injectable()
export class LoginService extends BaseService {

  constructor(
    private readonly http: HttpClient
  ) {
    super();
  }

  login(loginObj: Login) {
    return this.http.post(this.baseUrl + "/Authorization", loginObj);
  }
}
