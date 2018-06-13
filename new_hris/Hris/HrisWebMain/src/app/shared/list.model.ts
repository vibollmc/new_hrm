import { Injectable } from "@angular/core";

import { SelectableSettings } from "@progress/kendo-angular-grid";

import { ListService } from "./list.service";
import { BaseModel } from "./datamodel/base.model";
import { ResponseResult } from "./datamodel/response.result";
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
    this.service.get().subscribe(
      response => {
        var result = response.json() as ResponseResult;
        if (result.code === ResultCode.Success) {
          this.lstObj = result.data as T[];
        } else {
          this.lstObj = null;
        }
      });
  }

  save() {
    if (!this.obj) return;

    this.service.save(this.obj).subscribe(
      response => {
        var result = response.json() as ResponseResult;
        if (result.code === ResultCode.Success) {
          this.notificationProvider.saveSuccess();
          this.lstObj = result.data as T[];
          this.isAddingOrEditing = false;
        } else {
          this.notificationProvider.saveError(result.message);
        }
      });

  }

  updateStatus(obj: T | undefined) {
    if (!obj) return;

    this.service.updateStatus(obj).subscribe(
      response => {
        var result = response.json() as ResponseResult;
        if (result.code === ResultCode.Success) {
          this.notificationProvider.saveSuccess();
        } else {
          this.notificationProvider.saveError(result.message);
        }
      }
    );
  }

  delete() {
    if (!this.obj) return;

    this.notificationProvider.confirmDelete((result) => {
      if (result) {
        if (this.obj)
          this.service.delete(this.obj).subscribe(
            response => {
              var result = response.json() as ResponseResult;
              if (result.code === ResultCode.Success) {
                this.notificationProvider.deleteSuccess();
                this.lstObj = result.data as T[];
              } else {
                this.notificationProvider.deleteError(result.message);
              }
            }
          );
      }
    });
  }
}
