import { ClientDTO } from "./client";

export class PolicyDTO {
  public Id: string;
  public AmountInsured: number;
  public Email: string;
  public InceptionDate: Date;
  public InstallmentPayment: boolean;
  public ClientId: string;

  public Client: ClientDTO;
}
