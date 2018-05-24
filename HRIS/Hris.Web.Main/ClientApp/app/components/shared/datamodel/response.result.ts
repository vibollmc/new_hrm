import { ResultCode } from "../enum";

export class ResponseResult {
    constructor(code: ResultCode, data: any, message: string) {
        this.code = code;
        this.data = data;
        this.message = message;
    }
    code: ResultCode;
    data: any;
    message: string;
}