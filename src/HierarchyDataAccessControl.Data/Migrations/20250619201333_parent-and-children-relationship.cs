using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HierarchyDataAccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class parentandchildrenrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HierarchyNode_ParentId",
                table: "HierarchyNode",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HierarchyNode_HierarchyNode_ParentId",
                table: "HierarchyNode",
                column: "ParentId",
                principalTable: "HierarchyNode",
                principalColumn: "Id");

            migrationBuilder.InsertData(
                table: "HierarchyNode",
                columns: [ "Id", "Description", "TypeId", "ParentId"],
                values: new object[,]
                {
                    { "bb980eef-476c-4f93-8197-bb748a3e156a", "History Shows with Ms. Gabi", 1, null },
                    { "a66fe7d8-354a-41fe-8638-a54a5a6cf6c6", "Marketing", 2, "bb980eef-476c-4f93-8197-bb748a3e156a" },
                    { "696cf49f-76b0-47e8-97d2-3d64eead52e1", "Design Team", 3, "9433bb2a-8642-47b0-814a-eb5784489976" },
                    { "423d35c3-5ea2-4764-a044-c43a89ac80c2", "Bruno", 4, "696cf49f-76b0-47e8-97d2-3d64eead52e1" },
                    { "9433bb2a-8642-47b0-814a-eb5784489976", "Production and Editing", 2, "bb980eef-476c-4f93-8197-bb748a3e156a" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HierarchyNode_HierarchyNode_ParentId",
                table: "HierarchyNode");

            migrationBuilder.DropIndex(
                name: "IX_HierarchyNode_ParentId",
                table: "HierarchyNode");
        }
    }
}
