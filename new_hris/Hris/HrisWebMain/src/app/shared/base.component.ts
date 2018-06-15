import { AfterContentChecked, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import systemConfig from "./system.config";

declare var $: any;

export class BaseComponent implements AfterContentChecked, OnInit {
  heightBrowser: number;

  constructor(protected router: Router, pageTitle: string) {
    this.setPageTitle(pageTitle);
    this.heightBrowser = $(window).height();
  }

  get pageTitle(): string | null {
    return sessionStorage.getItem(systemConfig.pageTitle);
  }

  ngAfterContentChecked(): void {
    this.checkLoginStatus();
  }

  ngOnInit(): void {
    this.checkLoginStatus();
  }

  private checkLoginStatus() {
    if (!sessionStorage.getItem(systemConfig.keyToken))
      this.router.navigate(["login"]);
  }

  private setPageTitle(value: string | null) {
    if (value) sessionStorage.setItem(systemConfig.pageTitle, value);
    else sessionStorage.removeItem(systemConfig.pageTitle);
  }
}
