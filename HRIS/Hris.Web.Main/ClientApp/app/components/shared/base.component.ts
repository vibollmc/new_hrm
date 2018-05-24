import { Injectable, AfterContentChecked, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Injectable()
export class BaseComponent implements AfterContentChecked, OnInit {
    constructor(protected router: Router)
    { }

    ngAfterContentChecked(): void {
        this.checkLoginStatus();
    }

    ngOnInit(): void {
        this.checkLoginStatus();
    }

    private checkLoginStatus() {
        
    }
}