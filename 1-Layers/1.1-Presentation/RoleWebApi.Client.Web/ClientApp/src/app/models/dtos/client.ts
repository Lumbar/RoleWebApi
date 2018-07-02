import { PolicyDTO } from "./policy";

export class ClientDTO {
  public Id: string;
  public Name: string;
  public Email: string;
  public Role: string;

  public Policies: PolicyDTO[];

  public ClientDTO() {
    this.Policies = new Array<PolicyDTO>();
  }
}
