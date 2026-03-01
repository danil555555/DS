using DS.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DS.Infrastructure.Postgres.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");
        
        builder.HasKey(l => l.Id).HasName("location_id");

        builder.Property(l => l.Id).HasColumnName("id");

        builder.ComplexProperty(l => l.Name, ln =>
        {
            ln.Property(l => l.Name).HasColumnName("location_name").IsRequired();
        });

        builder.Property(l => l.Address).HasColumnType("jsonb").HasColumnName("address").IsRequired();

        builder.ComplexProperty(l => l.Timezone, ltz =>
        {
            ltz.Property(tz => tz.IanaCode).HasColumnName("iana_code").IsRequired();
        });
        
        builder.Property(l=> l.IsActive).HasColumnName("is_active").IsRequired();
        
        builder.Property(l => l.CreatedAt)
            .HasColumnName("created_at").IsRequired();
        
        builder.Property(l => l.UpdatedAt)
            .HasColumnName("updated_at").IsRequired();
    }
}