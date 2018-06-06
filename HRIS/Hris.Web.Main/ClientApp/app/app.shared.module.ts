//Angular module
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { RouterModule } from "@angular/router";
//End Angular module

//KendoUI Component
import { GridModule } from "@progress/kendo-angular-grid";
import { ButtonsModule } from "@progress/kendo-angular-buttons";
import { DialogsModule } from "@progress/kendo-angular-dialog";
//End KendoUI

//Common services
import { HttpClient } from "./components/shared/http.client";
import { ListModel } from "./components/shared/list.model";
import { ListService } from "./components/shared/list.service";
import { ShareModel } from "./components/shared/share.model";
import { ShareService } from "./components/shared/share.service";
//End common services

//Components
import { AppComponent } from "./components/app/app.component";
import { NavMenuComponent } from "./components/navmenu/navmenu.component";
import { HomeComponent } from "./components/home/home.component";
import { FetchDataComponent } from "./components/fetchdata/fetchdata.component";
import { CounterComponent } from "./components/counter/counter.component";
import { GenderComponent } from "./components/list/gender/gender.component";
//End Components

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
        ShareService
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        GridModule,
        ButtonsModule,
        DialogsModule,
        RouterModule.forRoot([
            { path: "", redirectTo: "home", pathMatch: "full" },
            { path: "home", component: HomeComponent },
            { path: "counter", component: CounterComponent },
            { path: "fetch-data", component: FetchDataComponent },
            { path: "gender", component: GenderComponent },
            { path: "**", redirectTo: "home" }
        ])
    ]
})
export class AppModuleShared {
}
