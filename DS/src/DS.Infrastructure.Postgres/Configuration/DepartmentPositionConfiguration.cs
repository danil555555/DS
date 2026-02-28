using DS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DS.Infrastructure.Postgres.Configuration;

public class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder.ToTable("department_positions");

        builder.HasKey(p => new { p.DepartmentId, p.PositionId }).HasName("pk_department_positions");

        builder.Property(p => p.PositionId).HasColumnName("position_id");

        builder.Property(p => p.DepartmentId).HasColumnName("department_id");

        builder.HasOne(d => d.Department)
            .WithMany(d => d.DepartmentPosition)
            .HasForeignKey(d => d.DepartmentId)
            .HasConstraintName("fk_department_positions_department_id")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(d => d.Position)
            .WithMany(d => d.DepartmentPosition)
            .HasForeignKey(d => d.PositionId)
            .HasConstraintName("fk_department_positions_position_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}