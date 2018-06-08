import {Injectable} from "@angular/core";
import { Http, Response } from "@angular/http";
import { ShareModel } from "./share.model";

import "rxjs/add/operator/finally";
import { Observable } from "rxjs/Observable";

@Injectable()
export class HttpClient {

    private readonly observable: Observable<Response>;
    constructor(private readonly http: Http,
        private readonly sm: ShareModel) {

        this.observable = new Observable<Response>(() => {

        });
    }

    get(url: string | undefined) {
        if (url)
            return this.http.get(url,
                {
                    headers: this.sm.createAuthorizationHeader()
                }).finally(() => { this.sm.isAjaxProcessing = false; });

        else return this.observable;
    }

    post(url: string | undefined, body: any) {
        if (url)
            return this.http.post(url,
                body,
                {
                    headers: this.sm.createAuthorizationHeader()
                }).finally(() => { this.sm.isAjaxProcessing = false; });
        else return this.observable;
    }

    put(url: string | undefined, body: any) {
        if (url)
            return this.http.put(url, body, { headers: this.sm.createAuthorizationHeader() })
                .finally(() => { this.sm.isAjaxProcessing = false; });
        else return this.observable;
    }

    delete(url: string | undefined) {
        if (url)
            return this.http.delete(url, { headers: this.sm.createAuthorizationHeader() })
                .finally(() => { this.sm.isAjaxProcessing = false });
        else return this.observable;
    }
}