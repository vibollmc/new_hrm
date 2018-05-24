import { Injectable } from "@angular/core";

import { ListService } from "./list.service";
import { BaseModel } from "./datamodel/base.model";
import { ResultCode } from "./enum";

@Injectable()
export class ListModel<T extends BaseModel> {
    obj: T;
    lstObj: T[] | null;

    constructor(
        private readonly service: ListService<T>
    ) { }

    setCollection(collectionName: string) {
        this.service.setUrlApi(collectionName);
    }

    loadData() {
        this.service.get().then(
            response => {
                if (response.code === ResultCode.Success) {
                    this.lstObj = response.data as T[];
                }
                else {
                    this.lstObj = null;
                }
            });
    }

    save() {
        if (this.obj === undefined || this.obj === null) return;

        if (this.obj.Id === undefined
            || this.obj.Id === null || this.obj.Id === 0) {
            this.service.addNew(this.obj).then(
                response => {
                    if (response.data === true) {
                        //TODO: MESSAGE NOTIFY SAVE SUCCESSFUL
                        this.loadData();
                    } else {
                        //TODO: MESSAGE NOTIFY SAVE FAIL
                    }
                });
        }
        else {
            this.service.update(this.obj).then(
                response => {
                    if (response.data === true) {
                        //TODO: MESSAGE NOTIFY SAVE SUCCESSFUL
                        this.loadData();
                    } else {
                        //TODO: MESSAGE NOTIFY SAVE FAIL
                    }
                }
            );
        }
    }

    updateStatus(id: number | null) {
        if (id === undefined || id === null || id === 0) return;

        this.service.updateStatus(id);
    }

    delete() {
        if (this.obj.Id === undefined
            || this.obj.Id === null || this.obj.Id === 0) return;

        //TODO: Confirm to deleted
        //MessageProvider.confirmDelete(null,
        //    (result) => {
        //        if (result === false) return;

        //        this._service.delete(this.obj._id).then(
        //            response => {
        //                if (response.data === true) {
        //                    MessageProvider.deleteSuccess();
        //                    this.loadData();
        //                }
        //                else MessageProvider.deleteError(response.message);
        //            }
        //        );
        //    });
    }
}