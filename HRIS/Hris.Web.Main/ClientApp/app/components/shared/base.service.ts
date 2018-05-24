import { Injectable, Inject } from "@angular/core";
import SystemConfig from "./system.config";

@Injectable()
export class BaseService {
    protected readonly baseUrl: string;
    constructor() {
        this.baseUrl = this.getBaseUrl();
    }

    private getBaseUrl(): string {
        return document.getElementsByTagName("base")[0].href;
    }

    handleError(error: any) {
        sessionStorage.setItem(SystemConfig.isAjaxProcessing, "false");

        //TODO: SHOW ERROR OR SOMETHING
    }
}