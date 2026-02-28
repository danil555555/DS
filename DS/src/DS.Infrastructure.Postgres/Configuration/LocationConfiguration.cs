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

        builder.ComplexProperty(l => l.Address, la =>
        {
            la.Property(a => a.Country).HasColumnName("country").IsRequired();
            
            la.Property(a => a.City).HasColumnName("city").IsRequired();
            
            la.Property(a => a.Street).HasColumnName("street").IsRequired();
            
            la.Property(a => a.NumberStreet).HasColumnName("number_street").IsRequired();
            
            la.Property(a => a.Room).HasColumnName("room").IsRequired();
            
            la.Property(a => a.PostalCode).HasColumnName("postal_code").IsRequired();
        });

        builder.ComplexProperty(l => l.Timezone, ltz =>
        {
            ltz.Property(tz => tz.IanaCode).HasColumnName("iana_code").IsRequired();
        });
        
        builder.Property(l=> l.IsActive).HasColumnName("is_active").IsRequired();
        
        builder.Property(l => l.CreatedAt)
            .HasConversion(l=> l.ToUniversalTime(), l => DateTime.SpecifyKind(l, DateTimeKind.Utc))
            .HasColumnName("created_at");
        
        builder.Property(l => l.UpdatedAt)
            .HasConversion(l => l.ToUniversalTime(), l => DateTime.SpecifyKind(l, DateTimeKind.Utc))
            .HasColumnName("updated_at");
    }
}