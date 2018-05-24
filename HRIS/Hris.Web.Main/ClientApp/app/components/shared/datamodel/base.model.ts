import {Status} from "../enum";

export class BaseModel {
    Id: number | null;
    Status: Status | null;

    CreatedAt: Date | null;
    CreatedBy: string | null;
    UpdatedAt: Date | null;
    UpdatedBy: string | null;

    constructor() {
        this.Status = Status.Active;
    }
}