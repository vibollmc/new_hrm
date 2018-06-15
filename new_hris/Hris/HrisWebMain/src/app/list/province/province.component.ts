import { Component } from "@angular/core";
import { Router } from "@angular/router";

import { SelectionEvent } from "@progress/kendo-angular-grid";

import { ListModel } from "../../shared/list.model";
import { Province } from "../../shared/datamodel/list/province";
import { BaseComponent } from "../../shared/base.component";

@Component({
  selector: "province",
  templateUrl: "./province.html"
})
export class ProvinceComponent extends BaseComponent {
  titleAddOrEdit: string;
  classAddOrEdit: string;
  constructor(public vm: ListModel<Province>,
    protected router: Router) {
    super(router, "Province");
  }

  ngOnInit(): void {
    super.ngOnInit();
    this.vm.setCollection("Province");
    this.vm.obj = new Province();
    this.vm.objSelected = new Province();
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
      this.vm.obj = new Province();
	  this.titleAddOrEdit = "Thêm danh mục";
      this.classAddOrEdit = "k-icon k-i-plus";
    }
    this.vm.isAddingOrEditing = true;
  }

  gridSelectionChange(event: SelectionEvent) {
    if (event.selectedRows && event.selectedRows.length > 0)
      Object.assign(this.vm.objSelected, event.selectedRows[0].dataItem);
    else
      this.vm.objSelected = new Province();
  }

  save() {
    this.vm.save();
    this.vm.objSelected = new Province();
  }

  delete() {
    Object.assign(this.vm.obj, this.vm.objSelected);
    this.vm.delete();
    this.vm.objSelected = new Province();
  }

  updateStatus(province: Province) {
    this.vm.updateStatus(province);
  }
}
