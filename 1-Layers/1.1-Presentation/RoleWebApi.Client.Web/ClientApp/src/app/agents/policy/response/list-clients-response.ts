import { BaseResponse } from "../../core/base-response";
import { ClientPagedList } from "../../../models/dtos";

export class ListClientsResponse extends BaseResponse {
  public Clients: ClientPagedList;

  constructor() {
    super();
    this.Clients = new ClientPagedList();
  }
}
