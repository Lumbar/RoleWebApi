namespace RoleWebApi.Infrastructure.Transport.PolicyModule.Request
{
    public class ListClientsRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
