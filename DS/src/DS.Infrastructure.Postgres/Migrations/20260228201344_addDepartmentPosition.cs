using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDepartmentPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_department_positions_departments_DepartmentId1",
                table: "department_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_department_positions_departments_department_id",
                table: "department_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_department_positions_positions_position_id",
                table: "department_positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_department_positions",
                table: "department_positions");

            migrationBuilder.DropIndex(
                name: "IX_department_positions_DepartmentId1",
                table: "department_positions");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "department_positions");

            migrationBuilder.AddPrimaryKey(
                name: "pk_department_positions",
                table: "department_positions",
                columns: new[] { "department_id", "position_id" });

            migrationBuilder.AddForeignKey(
                name: "fk_department_positions_department_id",
                table: "department_positions",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_department_positions_position_id",
                table: "department_positions",
                column: "position_id",
                principalTable: "positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_department_positions_department_id",
                table: "department_positions");

            migrationBuilder.DropForeignKey(
                name: "fk_department_positions_position_id",
                table: "department_positions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_department_positions",
                table: "department_positions");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId1",
                table: "department_positions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_department_positions",
                table: "department_positions",
                columns: new[] { "department_id", "position_id" });

            migrationBuilder.CreateIndex(
                name: "IX_department_positions_DepartmentId1",
                table: "department_positions",
                column: "DepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_department_positions_departments_DepartmentId1",
                table: "department_positions",
                column: "DepartmentId1",
                principalTable: "departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_department_positions_departments_department_id",
                table: "department_positions",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_department_positions_positions_position_id",
                table: "department_positions",
                column: "position_id",
                principalTable: "positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
