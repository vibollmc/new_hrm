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
import { DropDownListModule } from "@progress/kendo-angular-dropdowns";

//Common services
import { HttpClient } from "./shared/http.client";
import { ListModel } from "./shared/list.model";
import { ListService } from "./shared/list.service";
import { ShareModel } from "./shared/share.model";
import { ShareService } from "./shared/share.service";
import { NotificationProvider } from "./shared/notification.provider";
import { LocalStorage } from "./shared/local.storage";

//Components
import { AppComponent } from "./app.component";
import { LoginComponent } from "./login/login.component";
import { NavMenuComponent } from "./navmenu/navmenu.component";
import { HomeComponent } from "./home/home.component";
import { FetchDataComponent } from "./fetchdata/fetchdata.component";
import { CounterComponent } from "./counter/counter.component";
import { GenderComponent } from "./list/gender/gender.component";
import { CountryComponent } from "./list/country/country.component";
import { DistrictComponent } from "./list/district/district.component";
import { EducationComponent } from "./list/education/education.component";
import { ProvinceComponent } from "./list/province/province.component";
import { WardComponent } from "./list/ward/ward.component";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent,
    HomeComponent,
    GenderComponent,
    CountryComponent,
    DistrictComponent,
    EducationComponent,
    ProvinceComponent,
    WardComponent
  ],
  providers: [
    ListModel,
    ListService,
    HttpClient,
    ShareModel,
    ShareService,
    NotificationProvider,
    LocalStorage,
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
    DropDownListModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: "", redirectTo: "login", pathMatch: "full" },
      { path: "login", component: LoginComponent },
      { path: "home", component: HomeComponent },
      { path: "counter", component: CounterComponent },
      { path: "fetch-data", component: FetchDataComponent },
      { path: "gender", component: GenderComponent },
      { path: "country", component: CountryComponent },
      { path: "district", component: DistrictComponent },
      { path: "education", component: EducationComponent },
      { path: "province", component: ProvinceComponent },
      { path: "ward", component: WardComponent },
      { path: "**", redirectTo: "home" }
    ])
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName("base")[0].href;
}
