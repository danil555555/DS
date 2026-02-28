using DS.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DS.Infrastructure.Postgres.Configuration;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");
        
        builder.HasKey(p => p.Id).HasName("position_id");
        
        builder.Property(p => p.Id).HasColumnName("id");
        
        builder.ComplexProperty(p => p.Name, pn =>
        {
            pn.Property(p => p.Name).HasColumnName("position_name").IsRequired();
        });
        
        builder.Property(p => p.Description).HasColumnName("position_description").IsRequired();
        
        builder.Property(p => p.CreatedAt)
            .HasConversion(dt => dt.ToUniversalTime(), dt => DateTime.SpecifyKind(dt, DateTimeKind.Utc))
            .HasColumnName("created_at");
        
        builder.Property(p => p.UpdatedAt)
            .HasConversion(dt => dt.ToUniversalTime(), dt => DateTime.SpecifyKind(dt, DateTimeKind.Utc))
            .HasColumnName("updated_at");
        
        builder.Property(p => p.IsActive).HasColumnName("is_active").IsRequired();
    }
}