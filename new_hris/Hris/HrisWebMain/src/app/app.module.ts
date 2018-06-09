//Angular module
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { BrowserXhr, HttpModule } from "@angular/http";
import { RouterModule } from "@angular/router";

import { ToastrModule } from "ngx-toastr";
import { NgProgressModule, NgProgressBrowserXhr } from "ngx-progressbar";

//KendoUI Component
import { GridModule } from "@progress/kendo-angular-grid";
import { ButtonsModule } from "@progress/kendo-angular-buttons";
import { DialogsModule } from "@progress/kendo-angular-dialog";
import { SwitchModule, NumericTextBoxModule } from "@progress/kendo-angular-inputs";

//Common services
import { HttpClient } from "./shared/http.client";
import { ListModel } from "./shared/list.model";
import { ListService } from "./shared/list.service";
import { ShareModel } from "./shared/share.model";
import { ShareService } from "./shared/share.service";
import { NotificationProvider } from "./shared/notification.provider";

//Components
import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./navmenu/navmenu.component";
import { HomeComponent } from "./home/home.component";
import { FetchDataComponent } from "./fetchdata/fetchdata.component";
import { CounterComponent } from "./counter/counter.component";
import { GenderComponent } from "./list/gender/gender.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent,
    HomeComponent,
    GenderComponent
  ],
  providers: [
    ListModel,
    ListService,
    HttpClient,
    ShareModel,
    ShareService,
    NotificationProvider,
    { provide: "BASE_URL", useFactory: getBaseUrl },
    { provide: BrowserXhr, useClass: NgProgressBrowserXhr }
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    HttpModule,
    NgProgressModule,
    FormsModule,
    GridModule,
    ButtonsModule,
    DialogsModule,
    SwitchModule,
    NumericTextBoxModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: "", redirectTo: "home", pathMatch: "full" },
      { path: "home", component: HomeComponent },
      { path: "counter", component: CounterComponent },
      { path: "fetch-data", component: FetchDataComponent },
      { path: "gender", component: GenderComponent },
      { path: "**", redirectTo: "home" }
    ])
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName("base")[0].href;
}
