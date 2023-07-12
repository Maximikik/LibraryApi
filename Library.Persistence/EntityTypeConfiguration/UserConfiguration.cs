using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.HasIndex(entity => entity.Id).IsUnique();
        builder.HasIndex(entity => entity.Email).IsUnique();
        builder.Property(entity => entity.Password).HasMaxLength(20);
    }
}
