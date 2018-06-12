import { Injectable } from "@angular/core";
import { Headers } from "@angular/http";
import { ShareService } from "./share.service";


@Injectable()
export class ShareModel {
  constructor(private readonly service: ShareService) {
  }

  get currentPage(): string {
    return location.pathname.substr(1).toLowerCase();
  }

  get token(): string | null {
    return this.service.token;
  }

  set token(token: string | null) {
    this.service.token = token;
  }

  get isAjaxProcessing(): boolean {
    return this.service.isAjaxProcessing;
  }

  set isAjaxProcessing(value: boolean) {
    this.service.isAjaxProcessing = value;
  }

  get functionName(): string | null {
    return this.service.functionName;
  }

  set functionName(value: string | null) {
    this.service.functionName = value;
  }

  createAuthorizationHeader(): Headers {
    return this.service.createAuthorizationHeader();
  }
}
