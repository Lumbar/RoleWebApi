namespace RoleWebApi.Infrastructure.CrossCutting.DTO
{
    using System.Collections.Generic;

    public class ClientPagedList
    {
        public int IndexFrom { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<ClientDTO> Items { get; set; }
    }
}
