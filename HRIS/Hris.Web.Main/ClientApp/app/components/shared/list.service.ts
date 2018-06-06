import { Injectable } from "@angular/core";

import { HttpClient } from "./http.client";
import "rxjs/add/operator/toPromise";

import { BaseService } from "./base.service";
import { BaseModel } from "./datamodel/base.model";
import { ResponseResult } from "./datamodel/response.result";
import { Status } from "./enum";

@Injectable()
export class ListService<T extends BaseModel> extends BaseService {
    private urlGet: string | undefined;
    private urlAddNew: string | undefined;
    private urlUpdate: string | undefined;
    private urlDelete: string | undefined;
    private urlUpdateStatus: string | undefined;
    constructor(
        private readonly http: HttpClient
    ) {
        super();
    }

    setUrlApi(collectionName: string) {
        this.urlGet = `${this.baseUrl}/${collectionName}/List`;
        this.urlAddNew = `${this.baseUrl}/${collectionName}/Add`;
        this.urlUpdate = `${this.baseUrl}/${collectionName}/Update`;
        this.urlDelete = `${this.baseUrl}/${collectionName}/Delete`;
        this.urlUpdateStatus = `${this.baseUrl}/${collectionName}/Status`;
    }

    get(): Promise<ResponseResult> {
        return this.http.get(this.urlGet)
            .toPromise()
            .then(response => response.json() as ResponseResult)
            .catch(err => this.handleError(err));
    }
    addNew(obj: T): Promise<ResponseResult> {
        return this.http.post(this.urlAddNew, obj)
            .toPromise()
            .then(response => response.json() as ResponseResult)
            .catch(err => this.handleError(err));
    }
    update(obj: T): Promise<ResponseResult> {
        return this.http.post(this.urlUpdate, obj)
            .toPromise()
            .then(response => response.json() as ResponseResult)
            .catch(err => this.handleError(err));
    }
    delete(id: number): Promise<ResponseResult> {
        return this.http.post(this.urlDelete, { id: id })
            .toPromise()
            .then(response => response.json() as ResponseResult)
            .catch(this.handleError);
    }
    updateStatus(id: number): Promise<ResponseResult> {
        return this.http.post(this.urlUpdateStatus, { id: id})
            .toPromise()
            .then(response => response.json() as ResponseResult)
            .catch(err => this.handleError(err));
    }
}