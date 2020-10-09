using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoDataService.Migrations
{
    public partial class FixForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employees_departments_department_id",
                table: "employees");

            migrationBuilder.AlterColumn<long>(
                name: "department_id",
                table: "employees",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_employees_departments_department_id",
                table: "employees",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employees_departments_department_id",
                table: "employees");

            migrationBuilder.AlterColumn<long>(
                name: "department_id",
                table: "employees",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "fk_employees_departments_department_id",
                table: "employees",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
