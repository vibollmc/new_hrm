import {Status} from "../enum";

export class BaseModel {
    id: number | null | undefined;
    status: Status | null;

    createdAt: Date | null | undefined;
    createdBy: string | null | undefined;
    updatedAt: Date | null | undefined;
    updatedBy: string | null | undefined;

    constructor() {
        this.status = Status.Active;
    }
}