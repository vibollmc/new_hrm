import { Injectable } from "@angular/core";
import {
    DialogService,
    DialogAction
} from "@progress/kendo-angular-dialog";

import { ToastrService } from "ngx-toastr";

@Injectable()
export class NotificationProvider {

  constructor(private readonly dialogService: DialogService,
    private readonly toastr: ToastrService) {
  }

  error(message: string, title?: string) {
    this.toastr.error(message, title ? title : "Error");
  }

  success(message: string, title?: string) {
    this.toastr.success(message, title ? title : "Success");
  }

  warning(message: string, title?: string) {
    this.toastr.warning(message, title ? title : "Warning");
  }

  info(message: string, title?: string) {
    this.toastr.info(message, title ? title : "Info");
  }

  saveSuccess() {
    this.success("Lưu dữ liệu thành công", "Lưu dữ liệu");
  }

  saveError(message?: string) {
    this.error(`Lữu dữ liệu không thành công:<br>${message}`, "Lưu dữ liệu");
  }

  deleteSuccess() {
    this.success("Xóa dữ liệu thành công", "Xóa dữ liệu");
  }

  deleteError(message?: string) {
    this.error(`Xóa dữ liệu không thành công:<br>${message}`, "Xóa dữ liệu");
  }

  confirmDelete(callBack: (result: boolean) => void, message?: string) {
    this.confirm(message ? message : "Bạn muốn xóa dữ liệu này?", "Xác nhận", callBack);
  }

  confirm(message: string, title: string, callBack: (result: boolean) => void) {

    const dialog = this.dialogService.open({
      title: title,
      content: message,
      actions: [
        { text: "No" },
        { text: "Yes", primary: true }
      ],
      width: 400,
      height: 150,
      minWidth: 200
    });

    dialog.result.subscribe((result) => {
      let resultCallback = false;
      if ((result as DialogAction).text)
        if ((result as DialogAction).text === "Yes")
          resultCallback = true;

      callBack(resultCallback);
    });
  }

}
