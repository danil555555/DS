using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDepartmentLocationLibk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_department_locations_departments_department_id",
                table: "department_locations");

            migrationBuilder.DropForeignKey(
                name: "FK_department_locations_locations_location_id",
                table: "department_locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_department_locations",
                table: "department_locations");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "locations",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "locations",
                newName: "created_at");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId1",
                table: "department_locations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_department_location",
                table: "department_locations",
                columns: new[] { "department_id", "location_id" });

            migrationBuilder.CreateIndex(
                name: "IX_department_locations_LocationId1",
                table: "department_locations",
                column: "LocationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_department_locations_locations_LocationId1",
                table: "department_locations",
                column: "LocationId1",
                principalTable: "locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "fk_department_locations_department_id",
                table: "department_locations",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_department_locations_location_id",
                table: "department_locations",
                column: "location_id",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_department_locations_locations_LocationId1",
                table: "department_locations");

            migrationBuilder.DropForeignKey(
                name: "fk_department_locations_department_id",
                table: "department_locations");

            migrationBuilder.DropForeignKey(
                name: "fk_department_locations_location_id",
                table: "department_locations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_department_location",
                table: "department_locations");

            migrationBuilder.DropIndex(
                name: "IX_department_locations_LocationId1",
                table: "department_locations");

            migrationBuilder.DropColumn(
                name: "LocationId1",
                table: "department_locations");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "locations",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "locations",
                newName: "CreatedAt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_department_locations",
                table: "department_locations",
                columns: new[] { "department_id", "location_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_department_locations_departments_department_id",
                table: "department_locations",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_department_locations_locations_location_id",
                table: "department_locations",
                column: "location_id",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
