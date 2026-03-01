using System;
using DS.Domain.Locations;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class reviewEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_department_positions",
                table: "department_positions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_department_locations",
                table: "department_locations");

            migrationBuilder.DropColumn(
                name: "city",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "country",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "number_street",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "postal_code",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "room",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "street",
                table: "locations");

            migrationBuilder.AddColumn<Address>(
                name: "Address",
                table: "locations",
                type: "jsonb",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "DerpartmentPositionId",
                table: "department_positions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentLocationId",
                table: "department_locations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "pk_department_positions",
                table: "department_positions",
                column: "DerpartmentPositionId");

            migrationBuilder.AddPrimaryKey(
                name: "pk_department_locations",
                table: "department_locations",
                column: "DepartmentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_department_positions_department_id",
                table: "department_positions",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_department_locations_department_id",
                table: "department_locations",
                column: "department_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_department_positions",
                table: "department_positions");

            migrationBuilder.DropIndex(
                name: "IX_department_positions_department_id",
                table: "department_positions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_department_locations",
                table: "department_locations");

            migrationBuilder.DropIndex(
                name: "IX_department_locations_department_id",
                table: "department_locations");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "DerpartmentPositionId",
                table: "department_positions");

            migrationBuilder.DropColumn(
                name: "DepartmentLocationId",
                table: "department_locations");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "number_street",
                table: "locations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "postal_code",
                table: "locations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "room",
                table: "locations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "street",
                table: "locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_department_positions",
                table: "department_positions",
                columns: new[] { "department_id", "position_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_department_locations",
                table: "department_locations",
                columns: new[] { "department_id", "location_id" });
        }
    }
}
