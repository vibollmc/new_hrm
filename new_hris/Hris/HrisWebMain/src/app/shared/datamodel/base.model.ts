import {Status} from "../enum";

export class BaseModel {
    id?: number;
    status?: Status;

    createdAt?: Date;
    createdBy?: string;
    updatedAt?: Date;
    updatedBy?: string;

    constructor() {
        this.status = Status.Active;
    }
}
