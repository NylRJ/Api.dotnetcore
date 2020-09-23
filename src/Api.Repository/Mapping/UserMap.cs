using Api.Domain.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Repository.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder.OwnsOne(u => u.CPF, cpf =>
            {
                cpf.Property(c => c.Valor)
                .IsRequired()
                .HasColumnName("CPF")
                .HasColumnType("varchar(11)");



            });


            builder.Property(u => u.Email)
                .HasMaxLength(100);
        }
    }
}
