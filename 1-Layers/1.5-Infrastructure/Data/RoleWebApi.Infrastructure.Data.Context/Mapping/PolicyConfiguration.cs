namespace RoleWebApi.Infrastructure.Data.Context.Mapping
{
    using RoleWebApi.Infrastructure.Data.Entity.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> config)
        {
            config.ToTable("Policy");
            config.HasKey(c => c.Id);

            config.HasOne(d => d.Client)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("POLICY_CLIENT_FK");
        }
    }
}
