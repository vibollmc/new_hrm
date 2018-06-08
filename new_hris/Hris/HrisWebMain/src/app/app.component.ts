import { Component, AfterViewInit } from "@angular/core";
import { ShareModel } from "./shared/share.model";

declare var md: any;

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html"
})
export class AppComponent implements AfterViewInit {

  constructor(public readonly sm: ShareModel) {
  }

  ngAfterViewInit(): void {
    md.init();
    console.log("AppComponent.ngAfterViewInit was called");
  }
}
