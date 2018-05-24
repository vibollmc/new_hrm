import { Injectable } from "@angular/core";
import { Headers } from "@angular/http";
import { ShareService } from "./share.service";


@Injectable()
export class ShareModel {
    constructor(private readonly service: ShareService) {
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

    createAuthorizationHeader(): Headers {
        return this.service.createAuthorizationHeader();
    }
}