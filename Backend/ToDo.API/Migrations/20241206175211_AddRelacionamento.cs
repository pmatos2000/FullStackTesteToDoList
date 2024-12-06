using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tasks_user_id",
                table: "tasks",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_users_user_id",
                table: "tasks",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_users_user_id",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_user_id",
                table: "tasks");
        }
    }
}
