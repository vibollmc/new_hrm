import { Injectable } from "@angular/core";

import { HttpClient } from "./http.client";
import "rxjs/add/operator/toPromise";

import { BaseService } from "./base.service";
import { BaseModel } from "./datamodel/base.model";
import { ResponseResult } from "./datamodel/response.result";

@Injectable()
export class ListService<T extends BaseModel> extends BaseService {
    private urlGet: string | undefined;
    private urlSave: string | undefined;
    private urlDelete: string | undefined;
    private urlUpdateStatus: string | undefined;
    constructor(
        private readonly http: HttpClient
    ) {
        super();
    }

    setUrlApi(collectionName: string) {
        this.urlGet = `${this.baseUrl}/${collectionName}/List`;
        this.urlSave = `${this.baseUrl}/${collectionName}/Save`;
        this.urlDelete = `${this.baseUrl}/${collectionName}/Delete`;
        this.urlUpdateStatus = `${this.baseUrl}/${collectionName}/Status`;
    }

    get(): Promise<ResponseResult> {
        return this.http.get(this.urlGet)
            .toPromise()
            .then(response => response.json() as ResponseResult)
            .catch(err => this.handleError(err));
    }
    save(obj: T): Promise<ResponseResult> {
        return this.http.post(this.urlSave, obj)
            .toPromise()
            .then(response => response.json() as ResponseResult)
            .catch(err => this.handleError(err));
    }
    delete(obj: T): Promise<ResponseResult> {
        return this.http.post(this.urlDelete, obj)
            .toPromise()
            .then(response => response.json() as ResponseResult)
            .catch(this.handleError);
    }
    updateStatus(obj: T): Promise<ResponseResult> {
        return this.http.post(this.urlUpdateStatus, obj)
            .toPromise()
            .then(response => response.json() as ResponseResult)
            .catch(err => this.handleError(err));
    }
}