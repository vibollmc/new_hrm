import { Component, AfterViewInit } from '@angular/core';

declare var md: any;

@Component({
    selector: 'app',
    templateUrl: './app.component.html'
})
export class AppComponent implements AfterViewInit {

    ngAfterViewInit(): void {
        md.init();
    }
}
