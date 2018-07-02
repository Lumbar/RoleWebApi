import { ClientDTO } from "./index";

export class ClientPagedList {
  public PageIndex: number;
  public PageSize: number;
  public TotalCount: number;
  public TotalPages: number;
  public IndexFrom: number;
  public Items: ClientDTO[];

  constructor() {
    this.Items = new Array<ClientDTO>();
  }
}
