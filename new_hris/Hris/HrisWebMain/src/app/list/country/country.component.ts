import { Component } from "@angular/core";
import { Router } from "@angular/router";

import { SelectionEvent } from "@progress/kendo-angular-grid";

import { ListModel } from "../../shared/list.model";
import { Country } from "../../shared/datamodel/list/country";
import { BaseComponent } from "../../shared/base.component";

@Component({
  selector: "country",
  templateUrl: "./country.html"
})
export class CountryComponent extends BaseComponent {
  titleAddOrEdit: string;
  classAddOrEdit: string;
  constructor(public vm: ListModel<Country>,
    protected router: Router) {
    super(router, "Country");
  }

  ngOnInit(): void {
    super.ngOnInit();
    this.vm.setCollection("Country");
    this.vm.obj = new Country();
    this.vm.objSelected = new Country();
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
      this.vm.obj = new Country();
	  this.titleAddOrEdit = "Thêm danh mục";
      this.classAddOrEdit = "k-icon k-i-plus";
    }
    this.vm.isAddingOrEditing = true;
  }

  gridSelectionChange(event: SelectionEvent) {
    if (event.selectedRows && event.selectedRows.length > 0)
      Object.assign(this.vm.objSelected, event.selectedRows[0].dataItem);
    else
      this.vm.objSelected = new Country();
  }

  save() {
    this.vm.save();
    this.vm.objSelected = new Country();
  }

  delete() {
    Object.assign(this.vm.obj, this.vm.objSelected);
    this.vm.delete();
    this.vm.objSelected = new Country();
  }

  updateStatus(country: Country) {
    this.vm.updateStatus(country);
  }
}
