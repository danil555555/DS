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

        builder.HasKey(x => new { x.DepartmentId, x.LocationId })
            .HasName("pk_department_locations");

        builder.Property(x => x.DepartmentId)
            .HasColumnName("department_id");

        builder.Property(x => x.LocationId)
            .HasColumnName("location_id");

        builder.HasOne(x => x.Department)
            .WithMany(d => d.DepartmentLocation)
            .HasForeignKey(x => x.DepartmentId)
            .HasConstraintName("fk_department_locations_department")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Location)
            .WithMany(l => l.DepartmentLocations)
            .HasForeignKey(x => x.LocationId)
            .HasConstraintName("fk_department_locations_location")
            .OnDelete(DeleteBehavior.Cascade);
        
        /*builder.ToTable("department_locations");

builder.HasKey(dl => new
{
    dl.DepartmentId, dl.LocationId
}).HasName("pk_department_location");

builder.Property(dl => dl.LocationId)
    .HasColumnName("location_id");

builder.Property(dl => dl.DepartmentId)
    .HasColumnName("department_id");

builder.HasOne<Department>()
    .WithMany("_locations")
    .HasForeignKey(x => x.DepartmentId)
    .HasConstraintName("fk_department_locations_department_id")
    .OnDelete(DeleteBehavior.Cascade);

builder.HasOne<Location>()
    .WithMany("_departments")
    .HasForeignKey(x => x.LocationId)
    .HasConstraintName("fk_department_locations_location_id")
    .OnDelete(DeleteBehavior.Cascade);*/
    }
}