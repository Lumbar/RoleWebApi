import { ConnectTokenRequest } from "./request";
import { ConnectTokenResponse } from "./response";
import { NetworkManager, PostParameters } from "../networkmanager";
import { PathOperation } from "./path-operation";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";

@Injectable()
export class SecurityAgent {

  private networkManager: NetworkManager;
  private identityUrl: string = 'http://localhost:14760/';

  constructor(networkManager: NetworkManager) {
    this.networkManager = networkManager;
  }

  ConnectToken(connectTokenRequest: ConnectTokenRequest): Observable<ConnectTokenResponse> {
    let postParameters: PostParameters = new PostParameters();

    postParameters.PathOperation = this.identityUrl + PathOperation.ConnectToken;
    postParameters.RequestParameter = connectTokenRequest;

    return this.networkManager.IdentityServerPost(postParameters) as Observable<ConnectTokenResponse>;
  }
}
