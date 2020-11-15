using FaculOop.WebApi.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaculOop.WebApi.Infrastructure.UserAggregate.Configurations
{
    public class UserEntityMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(user => user.Id);

            builder.OwnsOne(user => user.Username,
                username => {
                    username.Property(x => x.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nome_usuario");
                });

            builder.OwnsOne(user => user.Password,
                password => {
                    password.Property(x => x.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("senha_usuario");
                });
        }
    }
}