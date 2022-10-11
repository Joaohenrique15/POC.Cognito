using POC.Cognito.Domain.Users.Entities;
using POC.Cognito.Domain.Users.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace POC.Cognito.Infra.Users.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder
               .Property(x => x.CognitoUserId)
               .HasColumnType("uuid");
            builder.HasIndex(x => x.CognitoUserId);

            builder
                .Property(x => x.Email)
                .HasColumnType("varchar(320)");

            builder
            .Property(x => x.Gender)
            .HasColumnType("varchar(10)");

            builder
             .Property(x => x.UserType)
             .HasConversion(toDB => (int)toDB,
                                fromDB => (EUserType)fromDB)
                .IsRequired();

            builder
            .Property(x => x.PhoneNumber)
            .HasColumnType("varchar(20)");

            //TODO Externalizar para tabela 1:N ou N:N
            builder.OwnsOne(owns => owns.Address, address =>
            {
                address.Property(x => x.CEP)
                        .HasColumnName("address.cep")
                        .HasColumnType("char(9)");

                address.Property(x => x.Street)
                       .HasColumnName("address.street")
                       .HasColumnType("varchar(150)");

                address.Property(x => x.Neighborhood)
                       .HasColumnName("address.neighborhood")
                       .HasColumnType("varchar(50)");

                address.Property(x => x.City)
                       .HasColumnName("address.city")
                       .HasColumnType("char(50)");

                address.Property(x => x.State)
                     .HasColumnName("address.state")
                     .HasColumnType("char(2)");

            });
        }
    }
}
