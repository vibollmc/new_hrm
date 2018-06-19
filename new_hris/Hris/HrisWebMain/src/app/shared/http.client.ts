import { Injectable } from "@angular/core";
import { Http, Response, Headers } from "@angular/http";

import { Observable } from "rxjs/Observable";
import { LocalStorage } from "./local.storage";

@Injectable()
export class HttpClient {

  private readonly observable: Observable<Response>;

  constructor(private readonly http: Http,
    private readonly ls: LocalStorage) {

    this.observable = new Observable<Response>(() => {

    });
  }

  private createAuthorizationHeader(): Headers {
    this.ls.isAjaxProcessing = true;
    let header = new Headers();
    header.append("Authorization", `Bearer ${this.ls.token === null ? "" : this.ls.token}`);
    return header;
  }

  get(url: string | undefined) {
    if (url)
      return this.http.get(url,
        {
          headers: this.createAuthorizationHeader()
        });
    else return this.observable;
  }

  post(url: string | undefined, body: any) {
    if (url)
      return this.http.post(url,
        body,
        {
          headers: this.createAuthorizationHeader()
        });
    else return this.observable;
  }

  put(url: string | undefined, body: any) {
    if (url)
      return this.http.put(url, body, { headers: this.createAuthorizationHeader() });
    else return this.observable;
  }

  delete(url: string | undefined) {
    if (url)
      return this.http.delete(url, { headers: this.createAuthorizationHeader() });
    else return this.observable;
  }
}
