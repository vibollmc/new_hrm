import { Injectable } from "@angular/core";
import { Headers } from "@angular/http";

import SystemConfig from "./system.config";
import { BaseService } from "./base.service";

@Injectable()
export class ShareService extends BaseService {

    get token(): string | null {
        return sessionStorage.getItem(SystemConfig.keyToken);
    }

    set token(value: string | null) {
        if (value) sessionStorage.setItem(SystemConfig.keyToken, value);
        else sessionStorage.removeItem(SystemConfig.keyToken);
    }

    get isAjaxProcessing(): boolean {
        if (sessionStorage.getItem(SystemConfig.isAjaxProcessing)) {
            return sessionStorage.getItem(SystemConfig.isAjaxProcessing) === "true";
        }

        return false;
    }

    set isAjaxProcessing(value: boolean) {
        if (value) sessionStorage.setItem(SystemConfig.isAjaxProcessing, value.toString());
        else sessionStorage.removeItem(SystemConfig.isAjaxProcessing);
    }

    createAuthorizationHeader(): Headers {
        this.isAjaxProcessing = true;
        let header = new Headers();
        header.append("x-access-token", this.token === null ? "" : this.token);
        return header;
    }
}