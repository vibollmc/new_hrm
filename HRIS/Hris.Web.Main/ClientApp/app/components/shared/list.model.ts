import { Injectable } from "@angular/core";

import { SelectableSettings } from "@progress/kendo-angular-grid";
import {
    DialogService,
    DialogAction,
    DialogCloseResult
    } from "@progress/kendo-angular-dialog";

import { ListService } from "./list.service";
import { BaseModel } from "./datamodel/base.model";
import { ResultCode } from "./enum";

@Injectable()
export class ListModel<T extends BaseModel> {
    obj: T | undefined;
    objSelected: T | undefined;
    lstObj: T[] | null | undefined;

    isAddingOrEditing: boolean;
    gridSelectableSettings: SelectableSettings;

    constructor(
        private readonly service: ListService<T>,
        private readonly dialogService: DialogService
    ) {
        this.isAddingOrEditing = false;
        this.gridSelectableSettings = {
            mode: "single",
            checkboxOnly: false
        };
    }

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
        if (!this.obj) return;

        this.service.save(this.obj).then(
            response => {
                if (response.data === true) {
                    //TODO: MESSAGE NOTIFY SAVE SUCCESSFUL
                    this.loadData();
                    this.isAddingOrEditing = false;
                } else {
                    //TODO: MESSAGE NOTIFY SAVE FAIL
                }
            });

    }

    updateStatus(obj: T | undefined) {
        if (!obj) return;

        this.service.updateStatus(obj);
    }

    delete() {
        if (!this.obj) return;

        const dialog = this.dialogService.open({
            title: "Please confirm",
            content: "Are you sure?",
            actions: [
                { text: "No" },
                { text: "Yes", primary: true }
            ],
            width: 450,
            height: 200,
            minWidth: 250
        });

        dialog.result.subscribe((result) => {
            if ((<DialogAction>result).text) {
                if ((<DialogAction>result).text === "Yes") {
                    if (this.obj)
                        this.service.delete(this.obj).then(
                            response => {
                                if (response.data === true) {
                                    //TODO: MESSAGE NOTIFY DELETE SUCCESSFUL
                                    this.loadData();
                                } else {
                                    //TODO: MESSAGE NOTIFY DELETE FAIL
                                }
                            }
                        );

                    console.log(result);
                }
            }

        });

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