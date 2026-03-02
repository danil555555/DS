using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_department_locations_departments_DepartmentId1",
                table: "department_locations");

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
                name: "IX_department_locations_DepartmentId1",
                table: "department_locations");

            migrationBuilder.DropIndex(
                name: "IX_department_locations_LocationId1",
                table: "department_locations");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "department_locations");

            migrationBuilder.DropColumn(
                name: "LocationId1",
                table: "department_locations");

            migrationBuilder.AddPrimaryKey(
                name: "pk_department_locations",
                table: "department_locations",
                columns: new[] { "department_id", "location_id" });

            migrationBuilder.AddForeignKey(
                name: "fk_department_locations_department",
                table: "department_locations",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_department_locations_location",
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
                name: "fk_department_locations_department",
                table: "department_locations");

            migrationBuilder.DropForeignKey(
                name: "fk_department_locations_location",
                table: "department_locations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_department_locations",
                table: "department_locations");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId1",
                table: "department_locations",
                type: "uuid",
                nullable: true);

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
                name: "IX_department_locations_DepartmentId1",
                table: "department_locations",
                column: "DepartmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_department_locations_LocationId1",
                table: "department_locations",
                column: "LocationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_department_locations_departments_DepartmentId1",
                table: "department_locations",
                column: "DepartmentId1",
                principalTable: "departments",
                principalColumn: "Id");

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
    }
}
