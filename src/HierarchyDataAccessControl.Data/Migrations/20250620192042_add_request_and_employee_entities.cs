using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HierarchyDataAccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_request_and_employee_entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: ["Id", "Name", "Team"],
                values: new object[,]
                {
                    { "5f847d32-6cd0-4e39-b76b-1b53da44bd9e", "Jason", "IT" },
                    { "738812ab-efc1-4c21-b7f5-d9d4f7b55431", "Lucas", "OP" },
                    { "a5d61b6b-2134-4c81-9b0c-ae9ac13251a5", "Leandro", "NW" },
                    { "aebbcea8-3b95-4cf7-b1c9-b4abe241077a", "July", "NW" },
                });

            migrationBuilder.InsertData(
                table: "HierarchyNodePermissions",
                columns: ["Id", "HierarchyNodeId", "Value"],
                values: new object[,]
                {
                   { "2dabf964-4e15-44a3-8d32-2823659b11e3", "5d6e2b16-11d6-4e45-9a41-eb94827f690d", "NW" },
                   { "e10231ab-7d8c-439d-b46f-dc9389297100", "5d6e2b16-11d6-4e45-9a41-eb94827f690d", "OP" },
                   { "40fa844c-b4c8-4b16-81b7-1fe40f27e7c4", "5d6e2b16-11d6-4e45-9a41-eb94827f690d", "IT" },
                });

            migrationBuilder.InsertData(
                table: "AccessPermissions",
                columns: ["PermissionId", "AccessId", "TypeId"],
                values: new object[,]
                {
                   { "2dabf964-4e15-44a3-8d32-2823659b11e3", "1ce73cdd-eb15-4ebf-b036-48caebc44072", 2 },
                   { "40fa844c-b4c8-4b16-81b7-1fe40f27e7c4", "80c17a2a-d2ef-4c48-8d34-adb8830bfcf9", 2 },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DeleteData(
                "HierarchyNodePermissions",
                "Id",
                [
                    "2dabf964-4e15-44a3-8d32-2823659b11e3",
                    "e10231ab-7d8c-439d-b46f-dc9389297100",
                    "40fa844c-b4c8-4b16-81b7-1fe40f27e7c4",
                ]);

            migrationBuilder.DeleteData(
                "AccessPermission",
                "PermissionId",
                [
                    "2dabf964-4e15-44a3-8d32-2823659b11e3",
                    "40fa844c-b4c8-4b16-81b7-1fe40f27e7c4",
                ]);
        }
    }
}
