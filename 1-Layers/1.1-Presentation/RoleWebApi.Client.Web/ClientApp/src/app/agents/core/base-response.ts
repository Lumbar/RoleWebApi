import { BaseResponseDTO } from "./base-response-dto";

export class BaseResponse {
  constructor() {
    this.StateResponse = new BaseResponseDTO();
  }
  public StateResponse: BaseResponseDTO;
}
