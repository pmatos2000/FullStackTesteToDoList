using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleteBehaviorSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_categories_category_id",
                table: "tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_categories_category_id",
                table: "tasks",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_categories_category_id",
                table: "tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_categories_category_id",
                table: "tasks",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id");
        }
    }
}
