using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_departments_DepartmentId",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_DepartmentId",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "departments");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "positions",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "positions",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "positions",
                newName: "position_description");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "positions",
                newName: "created_at");

            migrationBuilder.AlterColumn<string>(
                name: "position_description",
                table: "positions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "positions",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "position_description",
                table: "positions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "positions",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "positions",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "positions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "departments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_DepartmentId",
                table: "departments",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_departments_DepartmentId",
                table: "departments",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id");
        }
    }
}
