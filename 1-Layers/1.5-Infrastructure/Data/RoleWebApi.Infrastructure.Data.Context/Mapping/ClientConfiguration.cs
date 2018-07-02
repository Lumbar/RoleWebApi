namespace RoleWebApi.Infrastructure.Data.Context.Mapping
{
    using RoleWebApi.Infrastructure.Data.Entity.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> config)
        {
            config.ToTable("Client");
            config.HasKey(c => c.Id);
        }
    }
}
