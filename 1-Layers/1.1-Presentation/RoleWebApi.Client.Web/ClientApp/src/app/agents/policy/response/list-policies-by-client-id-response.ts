import { BaseResponse } from "../../core/base-response";
import { PolicyDTO } from "../../../models/dtos";

export class ListPoliciesByClientIdResponse extends BaseResponse {
  public Policies: PolicyDTO[];

  constructor() {
    super();
    this.Policies = new Array<PolicyDTO>();
  }
}
