using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace HierarchyDataAccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_access_permission_type_correct_some_table_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessPermission_HierarchyNodePermission_PermissionId",
                table: "AccessPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_HierarchyNodePermission_HierarchyNodes_HierarchyNodeId",
                table: "HierarchyNodePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HierarchyNodePermission",
                table: "HierarchyNodePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessPermission",
                table: "AccessPermission");

            migrationBuilder.RenameTable(
                name: "HierarchyNodePermission",
                newName: "HierarchyNodePermissions");

            migrationBuilder.RenameTable(
                name: "AccessPermission",
                newName: "AccessPermissions");

            migrationBuilder.RenameIndex(
                name: "IX_HierarchyNodePermission_HierarchyNodeId",
                table: "HierarchyNodePermissions",
                newName: "IX_HierarchyNodePermissions_HierarchyNodeId");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "AccessPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AccessPermissions",
                keyColumn: "PermissionId",
                keyValue: "1e44a378-c24d-4e07-bccc-229cc2fbd0c6",
                column: "TypeId",
                value: 1
                );

            migrationBuilder.AddPrimaryKey(
                name: "PK_HierarchyNodePermissions",
                table: "HierarchyNodePermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessPermissions",
                table: "AccessPermissions",
                columns: new[] { "PermissionId", "AccessId" });

            migrationBuilder.CreateTable(
                name: "AccessPermissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPermissionTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AccessPermissionTypes",
                columns: ["Id", "Description"],
                values: new object[,]
                {
                   { 1, "Global" },
                   { 2, "Unique" },
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessPermissions_TypeId",
                table: "AccessPermissions",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessPermissions_AccessPermissionTypes_TypeId",
                table: "AccessPermissions",
                column: "TypeId",
                principalTable: "AccessPermissionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccessPermissions_HierarchyNodePermissions_PermissionId",
                table: "AccessPermissions",
                column: "PermissionId",
                principalTable: "HierarchyNodePermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HierarchyNodePermissions_HierarchyNodes_HierarchyNodeId",
                table: "HierarchyNodePermissions",
                column: "HierarchyNodeId",
                principalTable: "HierarchyNodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessPermissions_AccessPermissionTypes_TypeId",
                table: "AccessPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AccessPermissions_HierarchyNodePermissions_PermissionId",
                table: "AccessPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_HierarchyNodePermissions_HierarchyNodes_HierarchyNodeId",
                table: "HierarchyNodePermissions");

            migrationBuilder.DropTable(
                name: "AccessPermissionTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HierarchyNodePermissions",
                table: "HierarchyNodePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessPermissions",
                table: "AccessPermissions");

            migrationBuilder.DropIndex(
                name: "IX_AccessPermissions_TypeId",
                table: "AccessPermissions");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "AccessPermissions");

            migrationBuilder.RenameTable(
                name: "HierarchyNodePermissions",
                newName: "HierarchyNodePermission");

            migrationBuilder.RenameTable(
                name: "AccessPermissions",
                newName: "AccessPermission");

            migrationBuilder.RenameIndex(
                name: "IX_HierarchyNodePermissions_HierarchyNodeId",
                table: "HierarchyNodePermission",
                newName: "IX_HierarchyNodePermission_HierarchyNodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HierarchyNodePermission",
                table: "HierarchyNodePermission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessPermission",
                table: "AccessPermission",
                columns: new[] { "PermissionId", "AccessId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AccessPermission_HierarchyNodePermission_PermissionId",
                table: "AccessPermission",
                column: "PermissionId",
                principalTable: "HierarchyNodePermission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HierarchyNodePermission_HierarchyNodes_HierarchyNodeId",
                table: "HierarchyNodePermission",
                column: "HierarchyNodeId",
                principalTable: "HierarchyNodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
