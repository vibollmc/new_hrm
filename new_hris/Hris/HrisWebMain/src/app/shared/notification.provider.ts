import { Injectable } from "@angular/core";
import {
    DialogService,
    DialogAction
} from "@progress/kendo-angular-dialog";

declare var toastr: any;

@Injectable()
export class NotificationProvider {

    constructor(private readonly dialogService: DialogService) {
        
    }

    saveSuccess() {
        toastr.success("Lưu dữ liệu thành công", "Lưu dữ liệu");
    }
    saveError(message?: string) {
        toastr.error(`Lữu dữ liệu không thành công:<br>${message}`, "Lưu dữ liệu");
    }

    deleteSuccess() {
        toastr.success("Xóa dữ liệu thành công", "Xóa dữ liệu");
    }
    deleteError(message?: string) {
        toastr.error(`Xóa dữ liệu không thành công:<br>${message}`, "Xóa dữ liệu");
    }

    confirmDelete(callBack: (result: boolean) => void, message?: string) {

        const dialog = this.dialogService.open({
            title: "Xác nhận",
            content: message ? message : "Bạn muốn xóa dữ liệu này?",
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
