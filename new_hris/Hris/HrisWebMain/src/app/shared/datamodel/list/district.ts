import { BaseModel } from "../base.model";

export class District extends BaseModel {
  name?: string;
  nameEn?: string;
  provinceId?: number;
  provinceName?: string;
  provinceNameEn?: string;
}
