import { Component } from "@angular/core";
import { Router } from "@angular/router";

import { SelectionEvent } from "@progress/kendo-angular-grid";

import { ListModel } from "../../shared/list.model";
import { District } from "../../shared/datamodel/list/district";
import { BaseComponent } from "../../shared/base.component";

@Component({
  selector: "district",
  templateUrl: "./district.html"
})
export class DistrictComponent extends BaseComponent {
  titleAddOrEdit: string;
  classAddOrEdit: string;
  constructor(public vm: ListModel<District>,
    protected router: Router) {
    super(router, "District");
  }

  ngOnInit(): void {
    super.ngOnInit();
    this.vm.setCollection("District");
    this.vm.obj = new District();
    this.vm.objSelected = new District();
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
      this.vm.obj = new District();
	  this.titleAddOrEdit = "Thêm danh mục";
      this.classAddOrEdit = "k-icon k-i-plus";
    }
    this.vm.isAddingOrEditing = true;
  }

  gridSelectionChange(event: SelectionEvent) {
    if (event.selectedRows && event.selectedRows.length > 0)
      Object.assign(this.vm.objSelected, event.selectedRows[0].dataItem);
    else
      this.vm.objSelected = new District();
  }

  save() {
    this.vm.save();
    this.vm.objSelected = new District();
  }

  delete() {
    Object.assign(this.vm.obj, this.vm.objSelected);
    this.vm.delete();
    this.vm.objSelected = new District();
  }

  updateStatus(district: District) {
    this.vm.updateStatus(district);
  }
}
