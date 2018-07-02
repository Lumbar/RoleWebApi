namespace RoleWebApi.Infrastructure.Transport.PolicyModule.Response
{
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using RoleWebApi.Infrastructure.Transport.Common;
    using System.Collections.Generic;

    public class ListClientsResponse : BaseResponse
    {
        public ClientPagedList Clients { get; set; }
    }
}
