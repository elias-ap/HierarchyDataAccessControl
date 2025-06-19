using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HierarchyDataAccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HierarchyNodeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HierarchyNodeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HierarchyNode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HierarchyNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HierarchyNode_HierarchyNodeType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "HierarchyNodeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HierarchyNode_TypeId",
                table: "HierarchyNode",
                column: "TypeId");

            migrationBuilder.InsertData(
                table: "HierarchyNodeType",
                columns: ["Description"],
                values: new object[,]
                {
                    { "Company" },
                    { "Department" },
                    { "Team" },
                    { "Employee" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HierarchyNode");

            migrationBuilder.DropTable(
                name: "HierarchyNodeType");
        }
    }
}
