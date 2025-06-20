using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HierarchyDataAccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class remove_hierarchy_third_level : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .DeleteData(
                "HierarchyNodeTypes",
                "Id",
                4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HierarchyNodeTypes",
                columns: ["Id", "Description"],
                values: new object[,]
                {
                    { 4, "Employee" }
                });
        }
    }
}
