import { Injectable } from "@angular/core";
import { PolicyAgent } from "../agents/policy/policy-agent";
import { PolicyDTO, ClientPagedList } from "../models/dtos";
import { ListClientsRequest, ListPoliciesByClientIdRequest } from "../agents/policy/request";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';

@Injectable()
export class PolicyService {

  constructor(private policyAgent: PolicyAgent) {
  }

  ListClients(id: string, name: string, email: string, role: string, pageIndex: number, pageSize: number): Observable<ClientPagedList> {
    let listClientsRequest: ListClientsRequest = new ListClientsRequest();

    listClientsRequest.Id = id;
    listClientsRequest.Name = name;
    listClientsRequest.Email = email;
    listClientsRequest.Role = role;
    listClientsRequest.PageIndex = pageIndex;
    listClientsRequest.PageSize = pageSize;

    return this.policyAgent.ListClients(listClientsRequest)
      .pipe(map((listClientsResponse) => listClientsResponse.Clients));
  }

  ListPoliciesByClientId(clientId: string): Observable<PolicyDTO[]> {
    let listPoliciesByClientIdRequest: ListPoliciesByClientIdRequest = new ListPoliciesByClientIdRequest();
    listPoliciesByClientIdRequest.ClientId = clientId;

    return this.policyAgent.ListPoliciesByClientId(listPoliciesByClientIdRequest)
      .pipe(map((listPoliciesByClientIdResponse) => listPoliciesByClientIdResponse.Policies));
  }
}
