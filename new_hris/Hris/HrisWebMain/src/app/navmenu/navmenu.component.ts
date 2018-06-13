import { Component, AfterViewInit } from "@angular/core";
declare var md: any;

@Component({
  selector: "nav-menu",
  templateUrl: "./navmenu.component.html"
})
export class NavMenuComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    md.init();
  }
}
