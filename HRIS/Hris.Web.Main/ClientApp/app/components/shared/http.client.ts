import {Injectable} from "@angular/core";
import { Http, Headers } from "@angular/http";
import { ShareModel } from "./share.model";

import "rxjs/add/operator/finally";

@Injectable()
export class HttpClient {
    constructor(private readonly http: Http,
        private readonly sm: ShareModel) { }

    get(url: string) {
        return this.http.get(url,
            {
                headers: this.sm.createAuthorizationHeader()
            }).finally(() => { this.sm.isAjaxProcessing = false; });
    }

    post(url: string, body: any) {
        return this.http.post(url,
            body,
            {
                headers: this.sm.createAuthorizationHeader()
            }).finally(() => { this.sm.isAjaxProcessing = false; });
    }

    put(url: string, body: any) {
        return this.http.put(url, body, { headers: this.sm.createAuthorizationHeader() })
            .finally(() => { this.sm.isAjaxProcessing = false; });
    }

    delete(url: string) {
        return this.http.delete(url, { headers: this.sm.createAuthorizationHeader() })
            .finally(() => { this.sm.isAjaxProcessing = false });
    }
}