using DS.Domain;
using DS.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DS.Infrastructure.Postgres.Configuration;

public class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder.ToTable("department_locations");

        builder.HasKey(x => x.DepartmentLocationId)
            .HasName("pk_department_locations");
        
        builder.Property(x => x.DepartmentLocationId)
            .HasColumnName("department_location_id");

        builder.Property(x => x.DepartmentId)
            .HasColumnName("department_id");

        builder.Property(x => x.LocationId)
            .HasColumnName("location_id");

        builder.HasOne<Department>()
            .WithMany(d => d.DepartmentLocation)
            .HasForeignKey(x => x.DepartmentId)
            .HasConstraintName("fk_department_locations_department")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Location>()
            .WithMany(l => l.DepartmentLocations)
            .HasForeignKey(x => x.LocationId)
            .HasConstraintName("fk_department_locations_location")
            .OnDelete(DeleteBehavior.Cascade);
    }
}