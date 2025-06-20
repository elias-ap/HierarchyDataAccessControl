using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HierarchyDataAccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_node_permission_relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HierarchyNodePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HierarchyNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HierarchyNodePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HierarchyNodePermission_HierarchyNodes_HierarchyNodeId",
                        column: x => x.HierarchyNodeId,
                        principalTable: "HierarchyNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessPermission",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPermission", x => new { x.PermissionId, x.AccessId });
                    table.ForeignKey(
                        name: "FK_AccessPermission_HierarchyNodePermission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "HierarchyNodePermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HierarchyNodePermission_HierarchyNodeId",
                table: "HierarchyNodePermission",
                column: "HierarchyNodeId");


            migrationBuilder.InsertData(
                table: "HierarchyNodePermission",
                columns: ["Id", "HierarchyNodeId", "Value"],
                values: new object[,]
                {
                   { "1e44a378-c24d-4e07-bccc-229cc2fbd0c6", "9433bb2a-8642-47b0-814a-eb5784489976", "PE" }
                });

            migrationBuilder.InsertData(
                table: "AccessPermission",
                columns: ["PermissionId", "AccessId"],
                values: new object[,]
                {
                   { "1e44a378-c24d-4e07-bccc-229cc2fbd0c6", "80c17a2a-d2ef-4c48-8d34-adb8830bfcf9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessPermission");

            migrationBuilder.DropTable(
                name: "HierarchyNodePermission");
        }
    }
}
