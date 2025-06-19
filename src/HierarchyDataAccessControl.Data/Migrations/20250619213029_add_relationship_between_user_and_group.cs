using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HierarchyDataAccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_relationship_between_user_and_group : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccessGroup",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessGroup", x => new { x.UserId, x.AccessGroupId });
                    table.ForeignKey(
                        name: "FK_UserAccessGroup_Groups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccessGroup_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessGroup_AccessGroupId",
                table: "UserAccessGroup",
                column: "AccessGroupId");

            migrationBuilder.InsertData(
                table: "UserAccessGroup",
                columns: ["UserId", "AccessGroupId"],
                values: new object[,]
                {
                   { "a24271b6-2749-4a02-80ff-52b24791fd9d", "2d30fe1c-b744-4f95-bd2a-89b2c0f3725b" },
                   { "69373c4a-2eb9-4544-a87f-62755d010f60", "2d30fe1c-b744-4f95-bd2a-89b2c0f3725b" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccessGroup");
        }
    }
}
