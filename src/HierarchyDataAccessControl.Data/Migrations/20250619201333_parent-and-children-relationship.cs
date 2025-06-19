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

            Guid levelOneParent = Guid.NewGuid();
            Guid levelTwoParent = Guid.NewGuid();
            Guid levelThreeParent = Guid.NewGuid();
            migrationBuilder.InsertData(
                table: "HierarchyNode",
                columns: [ "Id", "Description", "TypeId", "ParentId"],
                values: new object[,]
                {
                    { levelOneParent, "History Shows with Ms. Gabi", 1, null },
                    { levelTwoParent, "Marketing", 2, levelOneParent },
                    { levelThreeParent, "Design Team", 3, levelTwoParent },
                    { Guid.NewGuid(), "Bruno", 4, levelThreeParent },
                    { Guid.NewGuid(), "Production and Editing", 2, levelOneParent },
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
