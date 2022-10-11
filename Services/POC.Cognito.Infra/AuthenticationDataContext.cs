using POC.Cognito.Core.Interfaces;
using POC.Cognito.Domain.Users.Entities;
using POC.Cognito.Infra.Users.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Uow;
using IUnitOfWork = POC.Cognito.Core.Interfaces.IUnitOfWork;

namespace POC.Cognito.Infra
{
    public class AuthenticationDataContext : DbContext, IUnitOfWork
    {
        public AuthenticationDataContext(DbContextOptions<AuthenticationDataContext> options) : base(options){ }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<User> Users { get; set; }

        public async Task<bool> Commit()
        {
            //Garantindo que atualizo/crio uma data de cadastro sempre que commito um objeto que tenha essa propriedade
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedDate").IsModified = false;
                    entry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
