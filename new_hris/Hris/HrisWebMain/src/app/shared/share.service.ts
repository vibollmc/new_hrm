import { Injectable } from "@angular/core";

import { HttpClient } from "./http.client";
import { Status } from "./enum";
import { BaseService } from "./base.service";

@Injectable()
export class ShareService extends BaseService {

  constructor(private readonly http: HttpClient) {
    super();
  }

  getProvinceActive() {
    const url = `${this.baseUrl}/api/Province/${Status.Active}`;
    return this.http.get(url);
  }
}
