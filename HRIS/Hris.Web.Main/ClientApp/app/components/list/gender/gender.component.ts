import { Component } from "@angular/core";
import { Router } from "@angular/router";

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
        super(router);
    }

    ngOnInit(): void {
        super.ngOnInit();
        this.vm.setCollection("Gender");
        this.vm.obj = new Gender();
        this.vm.loadData();
    }

    select(obj: Gender | null) {
        if (obj !== null) {
            Object.assign(this.vm.obj, obj);
        } else {
            this.vm.obj = new Gender();
        }
    }

    save() {
        this.vm.save();
    }

    delete(obj: Gender) {
        this.vm.obj = obj;
        this.vm.delete();
    }

    updateStatus(id: number) {
        this.vm.updateStatus(id);
    }
}