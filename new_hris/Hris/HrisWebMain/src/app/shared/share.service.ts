import { Injectable } from "@angular/core";
import { Headers } from "@angular/http";

import systemConfig from "./system.config";
import { BaseService } from "./base.service";

@Injectable()
export class ShareService extends BaseService {

  get token(): string | null {
    return sessionStorage.getItem(systemConfig.keyToken);
  }

  set token(value: string | null) {
    if (value) sessionStorage.setItem(systemConfig.keyToken, value.toString());
    else sessionStorage.removeItem(systemConfig.keyToken);
  }

  get isAjaxProcessing(): boolean {
    if (sessionStorage.getItem(systemConfig.isAjaxProcessing)) {
      return sessionStorage.getItem(systemConfig.isAjaxProcessing) === "true";
    }

    return false;
  }

  set isAjaxProcessing(value: boolean) {
    if (value) sessionStorage.setItem(systemConfig.isAjaxProcessing, value.toString());
    else sessionStorage.removeItem(systemConfig.isAjaxProcessing);
  }

  get functionName(): string | null {
    return sessionStorage.getItem(systemConfig.pageTitle);
  }

  set functionName(value: string | null) {
    if (value) sessionStorage.setItem(systemConfig.pageTitle, value);
    else sessionStorage.removeItem(systemConfig.pageTitle);
  }

  createAuthorizationHeader(): Headers {
    this.isAjaxProcessing = true;
    let header = new Headers();
    header.append("Authorization", `Bearer ${this.token === null ? "" : this.token}`);
    return header;
  }
}
