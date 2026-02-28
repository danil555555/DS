using DS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DS.Infrastructure.Postgres.Configuration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");
        
        builder.HasKey(x => x.Id).HasName("department_id");
        
        builder.Property(d => d.Id).HasColumnName("id");
        
        builder.ComplexProperty(d => d.Name, dn =>
        {
            dn.Property(n => n.Name)
                .HasColumnName("name")
                .IsRequired();
        });

        builder.ComplexProperty(d => d.Identifier, di =>
        {
            di.Property(n => n.Identifier)
                .HasColumnName("identifier")
                .IsRequired();
        });

        builder.Property(d => d.ParentId).HasColumnName("parent_id");

        builder.ComplexProperty(d => d.Path, dp =>
        {
            dp.Property(p => p.Value).HasColumnName("path");
        });

        builder.Property(d => d.Depth).HasColumnName("depth");

        builder.Property(d => d.IsActive).HasColumnName("is_active");
        
        builder.Property(d => d.CreatedAt)
            .HasConversion(dt=> dt.ToUniversalTime(), dt => DateTime.SpecifyKind(dt, DateTimeKind.Utc))
            .HasColumnName("created_at");
        
        builder.Property(d => d.UpdatedAt)
            .HasConversion(dt => dt.ToUniversalTime(), dt => DateTime.SpecifyKind(dt, DateTimeKind.Utc))
            .HasColumnName("updated_at");
    }
}