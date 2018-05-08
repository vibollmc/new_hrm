import { Component, AfterViewInit } from '@angular/core';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html'
})
export class NavMenuComponent implements AfterViewInit {
    ngAfterViewInit(): void { console.log("NavMenuComponent"); }
}
