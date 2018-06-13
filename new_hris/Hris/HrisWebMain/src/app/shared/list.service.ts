import { Injectable } from "@angular/core";

import { HttpClient } from "./http.client";
import { BaseService } from "./base.service";
import { BaseModel } from "./datamodel/base.model";

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

    get() {
        return this.http.get(this.urlGet);
    }
    save(obj: T) {
        return this.http.post(this.urlSave, obj);
    }
    delete(obj: T) {
        return this.http.post(this.urlDelete, obj);
    }
    updateStatus(obj: T) {
        return this.http.post(this.urlUpdateStatus, obj);
    }
}
