namespace RoleWebApi.Infrastructure.Data.Entity.Domain
{
    using System.Collections.Generic;

    public class Client
    {
        public Client()
        {
            Policies = new HashSet<Policy>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<Policy> Policies { get; set; }
    }
}
