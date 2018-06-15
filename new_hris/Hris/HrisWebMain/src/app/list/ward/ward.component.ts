import { Component } from "@angular/core";
import { Router } from "@angular/router";

import { SelectionEvent } from "@progress/kendo-angular-grid";

import { ListModel } from "../../shared/list.model";
import { Ward } from "../../shared/datamodel/list/ward";
import { BaseComponent } from "../../shared/base.component";

@Component({
  selector: "ward",
  templateUrl: "./ward.html"
})
export class WardComponent extends BaseComponent {
  titleAddOrEdit: string;
  classAddOrEdit: string;
  constructor(public vm: ListModel<Ward>,
    protected router: Router) {
    super(router, "Ward");
  }

  ngOnInit(): void {
    super.ngOnInit();
    this.vm.setCollection("Ward");
    this.vm.obj = new Ward();
    this.vm.objSelected = new Ward();
    this.vm.loadData();
  }

  closeAddOrEdit() {
    this.vm.isAddingOrEditing = false;
  }

  openAddOrEdit(action: string) {
    if (action === "edit") {
      Object.assign(this.vm.obj, this.vm.objSelected);
	  this.titleAddOrEdit = "Chỉnh sửa danh mục";
      this.classAddOrEdit = "k-icon k-i-edit";
    } else {
      this.vm.obj = new Ward();
	  this.titleAddOrEdit = "Thêm danh mục";
      this.classAddOrEdit = "k-icon k-i-plus";
    }
    this.vm.isAddingOrEditing = true;
  }

  gridSelectionChange(event: SelectionEvent) {
    if (event.selectedRows && event.selectedRows.length > 0)
      Object.assign(this.vm.objSelected, event.selectedRows[0].dataItem);
    else
      this.vm.objSelected = new Ward();
  }

  save() {
    this.vm.save();
    this.vm.objSelected = new Ward();
  }

  delete() {
    Object.assign(this.vm.obj, this.vm.objSelected);
    this.vm.delete();
    this.vm.objSelected = new Ward();
  }

  updateStatus(ward: Ward) {
    this.vm.updateStatus(ward);
  }
}
