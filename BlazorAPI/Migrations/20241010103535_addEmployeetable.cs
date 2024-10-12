using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class addEmployeetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GmOldEmpId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SapEmpId = table.Column<int>(type: "int", nullable: true),
                    PersonnelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeSubgroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionCode = table.Column<int>(type: "int", nullable: true),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgUnitCode = table.Column<int>(type: "int", nullable: true),
                    OrgUnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateOnly>(type: "date", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: true),
                    StateCode = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L1ManagerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L1ManagerSapCode = table.Column<int>(type: "int", nullable: true),
                    L1ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
