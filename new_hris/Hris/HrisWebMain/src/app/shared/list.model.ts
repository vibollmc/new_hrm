import { Injectable } from "@angular/core";

import { SelectableSettings } from "@progress/kendo-angular-grid";

import { ListService } from "./list.service";
import { BaseModel } from "./datamodel/base.model";
import { ResultCode } from "./enum";
import { NotificationProvider } from "./notification.provider"

@Injectable()
export class ListModel<T extends BaseModel> {
    obj: T | undefined;
    objSelected: T | undefined;
    lstObj: T[] | null | undefined;

    isAddingOrEditing: boolean;
    gridSelectableSettings: SelectableSettings;

    constructor(
        private readonly service: ListService<T>,
        private readonly notificationProvider: NotificationProvider
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
                if (response.code === ResultCode.Success) {
                    this.notificationProvider.deleteSuccess();
                    this.lstObj = response.data as T[];
                    this.isAddingOrEditing = false;
                } else {
                    this.notificationProvider.saveError(response.message);
                }
            });

    }

    updateStatus(obj: T | undefined) {
        if (!obj) return;

        this.service.updateStatus(obj);
    }

    delete() {
        if (!this.obj) return;

        this.notificationProvider.confirmDelete((result) => {
            if (result) {
                if (this.obj)
                    this.service.delete(this.obj).then(
                        response => {
                            if (response.code === ResultCode.Success) {
                                this.notificationProvider.deleteSuccess();
                                this.lstObj = response.data as T[];
                            } else {
                                this.notificationProvider.deleteError(response.message);
                            }
                        }
                    );
            }
        });
    }
}
