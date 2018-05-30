import { Injectable } from "@angular/core";

import { HttpClient } from "./http.client";
import "rxjs/add/operator/toPromise";

import { BaseService } from "./base.service";
import { BaseModel } from "./datamodel/base.model";
import { ResponseResult } from "./datamodel/response.result";
import { Status } from "./enum";

@Injectable()
export class ListService<T extends BaseModel> extends BaseService {
    constructor(
        private readonly http: HttpClient,
        private urlGet: string,
        private urlAddNew: string,
        private urlUpdate: string,
        private urlDelete: string,
        private urlUpdateStatus: string
    ) {
        super();
    }

    setUrlApi(collectionName: string) {
        this.urlGet = `${this.baseUrl}/${collectionName}`;
        this.urlAddNew = `${this.baseUrl}/${collectionName}/add`;
        this.urlUpdate = `${this.baseUrl}/${collectionName}/update`;
        this.urlDelete = `${this.baseUrl}/${collectionName}/delete`;
        this.urlUpdateStatus = `${this.baseUrl}/${collectionName}/status`;
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
        return this.http.get(this.urlDelete + "/" + id)
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