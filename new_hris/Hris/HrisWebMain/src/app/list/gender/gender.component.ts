import { Component } from "@angular/core";
import { Router } from "@angular/router";

import { SelectionEvent } from "@progress/kendo-angular-grid";

import { ListModel } from "../../shared/list.model";
import { GenderModel } from "../../shared/datamodel/list/gender.model";
import { BaseComponent } from "../../shared/base.component";

@Component({
  selector: "gender",
  templateUrl: "./gender.html"
})
export class GenderComponent extends BaseComponent {

  constructor(public vm: ListModel<GenderModel>,
    protected router: Router) {
    super(router, "Giới tính");
  }

  ngOnInit(): void {
    super.ngOnInit();
    this.vm.setCollection("Gender");
    this.vm.obj = new GenderModel();
    this.vm.objSelected = new GenderModel();
    this.vm.loadData();
  }

  closeAddOrEdit() {
    this.vm.isAddingOrEditing = false;
  }

  openAddOrEdit(action: string) {
    if (action === "edit") {
      Object.assign(this.vm.obj, this.vm.objSelected);
    } else {
      this.vm.obj = new GenderModel();
    }
    this.vm.isAddingOrEditing = true;
  }

  gridSelectionChange(event: SelectionEvent) {
    if (event.selectedRows && event.selectedRows.length > 0)
      Object.assign(this.vm.objSelected, event.selectedRows[0].dataItem);
    else
      this.vm.objSelected = new GenderModel();
  }

  save() {
    this.vm.save();
  }

  delete() {
    Object.assign(this.vm.obj, this.vm.objSelected);
    this.vm.delete();
  }

  updateStatus(gender: GenderModel) {
    this.vm.updateStatus(gender);
  }
}
