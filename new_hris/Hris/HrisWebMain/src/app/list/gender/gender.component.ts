import { Component } from "@angular/core";
import { Router } from "@angular/router";

import { SelectionEvent } from "@progress/kendo-angular-grid";

import { ListModel } from "../../shared/list.model";
import { Gender } from "../../shared/datamodel/list/gender";
import { BaseComponent } from "../../shared/base.component";

@Component({
    selector: "gender",
    templateUrl: "./gender.html"
})

export class GenderComponent extends BaseComponent {

    constructor(public vm: ListModel<Gender>,
        protected router: Router) {
        super(router, "Giới tính");
    }

    ngOnInit(): void {
        super.ngOnInit();
        this.vm.setCollection("Gender");
        this.vm.obj = new Gender();
        this.vm.objSelected = new Gender();
        this.vm.loadData();
    }

    closeAddOrEdit() {
        this.vm.isAddingOrEditing = false;
    }

    openAddOrEdit(action: string) {
        if (action === "edit") {
            Object.assign(this.vm.obj, this.vm.objSelected);
        } else {
            this.vm.obj = new Gender();
        }
        this.vm.isAddingOrEditing = true;
    }

    gridSelectionChange(event: SelectionEvent) {
        if (event.selectedRows && event.selectedRows.length > 0)
            Object.assign(this.vm.objSelected, event.selectedRows[0].dataItem);
        else
            this.vm.objSelected = new Gender();
    }

    save() {
        this.vm.save();
    }

    delete() {
        Object.assign(this.vm.obj, this.vm.objSelected);
        this.vm.delete();
    }

    updateStatus(gender: Gender) {
        this.vm.updateStatus(gender);
    }
}