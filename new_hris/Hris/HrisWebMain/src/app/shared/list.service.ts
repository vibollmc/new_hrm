import { Injectable } from "@angular/core";

import { HttpClient } from "./http.client";
import { BaseService } from "./base.service";
import { BaseModel } from "./datamodel/base.model";

@Injectable()
export class ListService<T extends BaseModel> extends BaseService {
  private urlApi: string | undefined;
  private urlApiDelete: string | undefined;
  private urlApiUpdateStatus: string | undefined;

  constructor(
    private readonly http: HttpClient
  ) {
    super();
  }

  setUrlApi(collectionName: string) {
    this.urlApi = `${this.baseUrl}/api/${collectionName}`;
    this.urlApiDelete = `${this.baseUrl}/api/${collectionName}/Delete`;
    this.urlApiUpdateStatus = `${this.baseUrl}/api/${collectionName}/Status`;
  }

  get() {
    return this.http.get(this.urlApi);
  }

  save(obj: T) {
    return this.http.post(this.urlApi, obj);
  }

  delete(obj: T) {
    return this.http.post(this.urlApiDelete, obj);
  }

  updateStatus(obj: T) {
    return this.http.post(this.urlApiUpdateStatus, obj);
  }
}
