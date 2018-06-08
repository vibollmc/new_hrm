import { AfterContentChecked, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import SystemConfig from "./system.config";

export class BaseComponent implements AfterContentChecked, OnInit {
    constructor(protected router: Router, pageTitle: string) {
        this.setPageTitle(pageTitle);
    }

    get pageTitle(): string | null {
        return sessionStorage.getItem(SystemConfig.pageTitle);
    }

    ngAfterContentChecked(): void {
        this.checkLoginStatus();
    }

    ngOnInit(): void {
        this.checkLoginStatus();
    }

    private checkLoginStatus() {
        
    }
    
    private setPageTitle(value: string | null) {
        if (value) sessionStorage.setItem(SystemConfig.pageTitle, value);
        else sessionStorage.removeItem(SystemConfig.pageTitle);
    }
}
