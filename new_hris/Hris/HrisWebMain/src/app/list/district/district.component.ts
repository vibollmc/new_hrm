import { Component } from "@angular/core";
import { Router } from "@angular/router";

import { SelectionEvent } from "@progress/kendo-angular-grid";

import { ListModel } from "../../shared/list.model";
import { District } from "../../shared/datamodel/list/district";
import { Province } from "../../shared/datamodel/list/province";
import { BaseComponent } from "../../shared/base.component";
import { ShareModel } from "../../shared/share.model";
import { ResponseResult } from "../../shared/datamodel/response.result";
import { ResultCode } from "../../shared/enum";

@Component({
  selector: "district",
  templateUrl: "./district.html"
})
export class DistrictComponent extends BaseComponent {
  titleAddOrEdit: string;
  classAddOrEdit: string;
  lstProvince: Province[];
  lstProvinceSource: Province[];
  province: Province;
  constructor(public vm: ListModel<District>,
    private readonly sm: ShareModel,
    protected router: Router) {
    super(router, "District");
    this.getProvice();
  }

  ngOnInit(): void {
    super.ngOnInit();
    this.vm.setCollection("District");
    this.vm.obj = new District();
    this.vm.objSelected = new District();
    this.vm.loadData();
  }

  private getProvice() {
    this.sm.getProvinceActive()
      .subscribe(response => {
        var result = response.json() as ResponseResult;
        if (result.code === ResultCode.Success) {
          this.lstProvinceSource = result.data;
        } else {
          this.lstProvinceSource = new Array<Province>();
        }

        this.lstProvince = this.lstProvinceSource.slice();
      });
  }

  provinceFilter(value: string) {
    this.lstProvince = this.lstProvinceSource.filter((s) => s.name.toLowerCase().indexOf(value.toLowerCase()) !== -1);
  }

  closeAddOrEdit() {
    this.vm.isAddingOrEditing = false;
  }

  openAddOrEdit(action: string) {
    if (action === "edit") {
      Object.assign(this.vm.obj, this.vm.objSelected);
	    this.titleAddOrEdit = "Chỉnh sửa danh mục";
      this.classAddOrEdit = "k-icon k-i-edit";
      this.province = this.lstProvinceSource.find(x => x.id === this.vm.obj.provinceId);
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
    this.vm.obj.provinceId = this.province.id;
    this.vm.obj.provinceName = this.province.name;
    this.vm.obj.provinceNameEn = this.province.nameEn;
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
