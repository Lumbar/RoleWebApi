namespace RoleWebApi.Infrastructure.Data.Context
{
    using RoleWebApi.Infrastructure.Data.Context.Mapping;
    using RoleWebApi.Infrastructure.Data.Entity.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Principal;

    public class PolicyContext : DbContext
    {
        public PolicyContext(DbContextOptions<PolicyContext> options, IPrincipal principal) : base(options)
        {
            _principal = principal as ClaimsPrincipal;
        }

        private readonly ClaimsPrincipal _principal;

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.EnableAutoHistory(null);

            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new PolicyConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
