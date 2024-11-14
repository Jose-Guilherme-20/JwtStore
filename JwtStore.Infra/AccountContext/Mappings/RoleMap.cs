using JwtStore.Core.Context.AccountContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtStore.Infra.AccountContext.Mappings;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("dbo", "Role");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120)
            .IsRequired(true);
    }
}