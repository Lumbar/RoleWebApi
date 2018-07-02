namespace RoleWebApi.Infrastructure.Transport.Common
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            StateResponse = new BaseResponseDTO();
        }
        public BaseResponseDTO StateResponse { get; set; }
    }
}
