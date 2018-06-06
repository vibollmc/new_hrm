import { Injectable } from "@angular/core";

import { ListService } from "./list.service";
import { BaseModel } from "./datamodel/base.model";
import { ResultCode } from "./enum";

@Injectable()
export class ListModel<T extends BaseModel> {
    obj: T | undefined;
    lstObj: T[] | null | undefined;
    constructor(
        private readonly service: ListService<T>
    ) {
    }

    setCollection(collectionName: string) {
        this.service.setUrlApi(collectionName);
    }

    loadData() {
        this.service.get().then(
            response => {
                if (response.code == ResultCode.Success) {
                    this.lstObj = response.data as T[];
                }
                else {
                    this.lstObj = null;
                }
            });
    }

    save() {
        if (!this.obj) return;

        if (!this.obj.id) {

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
        if (!id) return;

        this.service.updateStatus(id);
    }

    delete() {
        if (!this.obj) return;
        if (!this.obj.id) return;

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