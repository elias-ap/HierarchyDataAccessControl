using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HierarchyDataAccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_users_on_database_and_set_table_names_in_plural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HierarchyNode_HierarchyNodeType_TypeId",
                table: "HierarchyNode");

            migrationBuilder.DropForeignKey(
                name: "FK_HierarchyNode_HierarchyNode_ParentId",
                table: "HierarchyNode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HierarchyNodeType",
                table: "HierarchyNodeType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HierarchyNode",
                table: "HierarchyNode");

            migrationBuilder.RenameTable(
                name: "HierarchyNodeType",
                newName: "HierarchyNodeTypes");

            migrationBuilder.RenameTable(
                name: "HierarchyNode",
                newName: "HierarchyNodes");

            migrationBuilder.RenameIndex(
                name: "IX_HierarchyNode_TypeId",
                table: "HierarchyNodes",
                newName: "IX_HierarchyNodes_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_HierarchyNode_ParentId",
                table: "HierarchyNodes",
                newName: "IX_HierarchyNodes_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HierarchyNodeTypes",
                table: "HierarchyNodeTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HierarchyNodes",
                table: "HierarchyNodes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HierarchyNodes_HierarchyNodeTypes_TypeId",
                table: "HierarchyNodes",
                column: "TypeId",
                principalTable: "HierarchyNodeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HierarchyNodes_HierarchyNodes_ParentId",
                table: "HierarchyNodes",
                column: "ParentId",
                principalTable: "HierarchyNodes",
                principalColumn: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: ["Id", "Name"],
                values: new object[,]
                {
                   { "80c17a2a-d2ef-4c48-8d34-adb8830bfcf9", "Jefferson" },
                   { "1ce73cdd-eb15-4ebf-b036-48caebc44072", "Bruna" },
                   { "69373c4a-2eb9-4544-a87f-62755d010f60", "Geovana" },
                   { "a24271b6-2749-4a02-80ff-52b24791fd9d", "Syrla" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HierarchyNodes_HierarchyNodeTypes_TypeId",
                table: "HierarchyNodes");

            migrationBuilder.DropForeignKey(
                name: "FK_HierarchyNodes_HierarchyNodes_ParentId",
                table: "HierarchyNodes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HierarchyNodeTypes",
                table: "HierarchyNodeTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HierarchyNodes",
                table: "HierarchyNodes");

            migrationBuilder.RenameTable(
                name: "HierarchyNodeTypes",
                newName: "HierarchyNodeType");

            migrationBuilder.RenameTable(
                name: "HierarchyNodes",
                newName: "HierarchyNode");

            migrationBuilder.RenameIndex(
                name: "IX_HierarchyNodes_TypeId",
                table: "HierarchyNode",
                newName: "IX_HierarchyNode_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_HierarchyNodes_ParentId",
                table: "HierarchyNode",
                newName: "IX_HierarchyNode_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HierarchyNodeType",
                table: "HierarchyNodeType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HierarchyNode",
                table: "HierarchyNode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HierarchyNode_HierarchyNodeType_TypeId",
                table: "HierarchyNode",
                column: "TypeId",
                principalTable: "HierarchyNodeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HierarchyNode_HierarchyNode_ParentId",
                table: "HierarchyNode",
                column: "ParentId",
                principalTable: "HierarchyNode",
                principalColumn: "Id");
        }
    }
}
