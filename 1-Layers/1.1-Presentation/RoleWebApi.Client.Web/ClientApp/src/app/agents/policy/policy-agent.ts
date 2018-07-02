import { ListClientsRequest, ListPoliciesByClientIdRequest } from "./request";
import { ListClientsResponse, ListPoliciesByClientIdResponse } from "./response";
import { NetworkManager, PostParameters } from "../networkmanager";
import { PathOperation } from "./path-operation";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";

@Injectable()
export class PolicyAgent {

  private networkManager: NetworkManager;
  private policyUrl: string = 'http://localhost:15702/api/';

  constructor(networkManager: NetworkManager) {
    this.networkManager = networkManager;
  }

  ListClients(listClientsRequest: ListClientsRequest): Observable<ListClientsResponse> {
    let postParameters: PostParameters = new PostParameters();

    postParameters.PathOperation = this.policyUrl + PathOperation.ListClients;
    postParameters.RequestParameter = listClientsRequest;

    return this.networkManager.Post(postParameters) as Observable<ListClientsResponse>;
  }

  ListPoliciesByClientId(listPoliciesByClientIdRequest: ListPoliciesByClientIdRequest): Observable<ListPoliciesByClientIdResponse> {
    let postParameters: PostParameters = new PostParameters();

    postParameters.PathOperation = this.policyUrl + PathOperation.ListPoliciesByClientId;
    postParameters.RequestParameter = listPoliciesByClientIdRequest;

    return this.networkManager.Post(postParameters) as Observable<ListPoliciesByClientIdResponse>;
  }
}
