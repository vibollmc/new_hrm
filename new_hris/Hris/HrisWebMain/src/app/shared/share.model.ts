import { Injectable } from "@angular/core";
import { ShareService } from "./share.service";
import { LocalStorage } from "./local.storage";

@Injectable()
export class ShareModel {
  constructor(private readonly service: ShareService,
    private readonly localStorage: LocalStorage) {
  }

  get currentPage(): string {
    return location.pathname.substr(1).toLowerCase();
  }

  get token(): string | null {
    return this.localStorage.token;
  }

  set token(token: string | null) {
    this.localStorage.token = token;
  }

  get isAjaxProcessing(): boolean {
    return this.localStorage.isAjaxProcessing;
  }

  set isAjaxProcessing(value: boolean) {
    this.localStorage.isAjaxProcessing = value;
  }

  get functionName(): string | null {
    return this.localStorage.functionName;
  }

  set functionName(value: string | null) {
    this.localStorage.functionName = value;
  }

  getProvinceActive() {
    return this.service.getProvinceActive();
  }
}
