using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HierarchyDataAccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_access_groups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: ["Id", "Description"],
                values: new object[,]
                {
                   { "2d30fe1c-b744-4f95-bd2a-89b2c0f3725b", "Global Managers" },
                   { "b23fa5d5-5dde-4b96-a393-6316ff5377a3", "Technology Information" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
