import { Component } from "@angular/core";
import { Router } from "@angular/router";

import { SelectionEvent } from "@progress/kendo-angular-grid";

import { ListModel } from "../../shared/list.model";
import { Education } from "../../shared/datamodel/list/education";
import { BaseComponent } from "../../shared/base.component";

@Component({
  selector: "education",
  templateUrl: "./education.html"
})
export class EducationComponent extends BaseComponent {
  titleAddOrEdit: string;
  classAddOrEdit: string;
  constructor(public vm: ListModel<Education>,
    protected router: Router) {
    super(router, "Education");
  }

  ngOnInit(): void {
    super.ngOnInit();
    this.vm.setCollection("Education");
    this.vm.obj = new Education();
    this.vm.objSelected = new Education();
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
      this.vm.obj = new Education();
	  this.titleAddOrEdit = "Thêm danh mục";
      this.classAddOrEdit = "k-icon k-i-plus";
    }
    this.vm.isAddingOrEditing = true;
  }

  gridSelectionChange(event: SelectionEvent) {
    if (event.selectedRows && event.selectedRows.length > 0)
      Object.assign(this.vm.objSelected, event.selectedRows[0].dataItem);
    else
      this.vm.objSelected = new Education();
  }

  save() {
    this.vm.save();
    this.vm.objSelected = new Education();
  }

  delete() {
    Object.assign(this.vm.obj, this.vm.objSelected);
    this.vm.delete();
    this.vm.objSelected = new Education();
  }

  updateStatus(education: Education) {
    this.vm.updateStatus(education);
  }
}
