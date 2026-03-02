using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class afterReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "locations",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "DerpartmentPositionId",
                table: "department_positions",
                newName: "derpartment_position_id");

            migrationBuilder.RenameColumn(
                name: "DepartmentLocationId",
                table: "department_locations",
                newName: "department_location_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address",
                table: "locations",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "derpartment_position_id",
                table: "department_positions",
                newName: "DerpartmentPositionId");

            migrationBuilder.RenameColumn(
                name: "department_location_id",
                table: "department_locations",
                newName: "DepartmentLocationId");
        }
    }
}
