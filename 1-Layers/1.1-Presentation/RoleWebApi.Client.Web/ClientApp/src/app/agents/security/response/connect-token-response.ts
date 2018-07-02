import { BaseResponse } from "../../core/base-response";

export class ConnectTokenResponse extends BaseResponse {
  public access_token: string;
  public expires_in: string;
  public token_type: string;
}
