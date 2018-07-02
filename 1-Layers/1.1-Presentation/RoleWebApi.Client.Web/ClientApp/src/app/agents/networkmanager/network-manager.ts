import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";
import { BaseResponse } from "../core/base-response";
import { PostParameters } from "./post-parameters";
import { ConnectTokenResponse } from "../security/response/index";

@Injectable()
export class NetworkManager {

  private resourceOwnerClientSecret: string = 'B3lCorPpr0tocolsEv3nts';

  constructor(
    private httpClient: HttpClient) {
  }

  Post(postParameters: PostParameters): Observable<BaseResponse> {

    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    const options = { headers: headers };
    var parameters = postParameters.RequestParameter || null;
    let _self = this;

    return Observable.create(observer => {

      this.httpClient.post(`${postParameters.PathOperation}`, JSON.stringify(parameters), options)
        .subscribe((data) => {

          try {
            let response: BaseResponse = <BaseResponse>data;
            
            if (response.StateResponse.HasError) {
              observer.error(response);
            } else {
              observer.next(data);
            }
          } catch (e) {
            observer.error(e);
          } finally {
            observer.complete();
          }
        }, error => this.ErrorHandler(error, _self));
    });
  }

  IdentityServerPost(postParameters: PostParameters): Observable<BaseResponse> {
    const headers = new HttpHeaders({ 'content-type': 'application/x-www-form-urlencoded' });
    const options = { headers: headers };
    var parameters = postParameters.RequestParameter || null;
    let _self = this;

    let body = new URLSearchParams();
    body.set('grant_type', "password");
    body.set('client_id', "resourceownerclient");
    body.set('client_secret', "SecurityEv3nts");
    body.set('scope', "apiInformation");
    body.set('username', postParameters.RequestParameter.username);
    body.set('password', postParameters.RequestParameter.password);

    return Observable.create(observer => {
      this.httpClient.post(`${postParameters.PathOperation}`, body.toString(), options)
        .subscribe((data : ConnectTokenResponse) => {
          try {
            let response: ConnectTokenResponse = <ConnectTokenResponse>data;
            if (data.access_token) {
              observer.next(response);
            } else {
              observer.error("Unexpected error");
            }
          } catch (e) {
            observer.error(e);
          } finally {
            observer.complete();
          }
        }, error => {
          if (error.status === 400 && error.error.error_description == "invalid_username_or_password") {
            observer.error("Invalid username or password");
            observer.complete();
          }
          else if (error.status === 400 && error.error.error == "invalid_client") {
            observer.error("Invalid Client");
            observer.complete();
          }
          else {
            this.ErrorHandler(error, _self);
          }
        });
    });
  }

  ErrorHandler(error, _self) {
    if (error.status != 401) {
      console.error('CUSTOM ERROR');
      console.log(error);
      alert("Unexpected error");
    }
  }
}
