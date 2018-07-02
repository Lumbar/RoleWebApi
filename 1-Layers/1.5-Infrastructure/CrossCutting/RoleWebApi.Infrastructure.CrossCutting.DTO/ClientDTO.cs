namespace RoleWebApi.Infrastructure.CrossCutting.DTO
{
    using System.Collections.Generic;

    public class ClientDTO
    {
        public ClientDTO()
        {
            Policies = new HashSet<PolicyDTO>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<PolicyDTO> Policies { get; set; }
    }
}
