using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KanbanBoard.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Medium"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Personal" },
                    { 3, "Shopping" },
                    { 4, "Health" },
                    { 5, "Learning" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "DueDate", "Priority", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2025, 8, 15, 10, 0, 0, 0, DateTimeKind.Utc), "Create a fully functional kanban board with drag & drop", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High", 1, "Build Kanban Board" },
                    { 2, 3, new DateTime(2025, 8, 20, 14, 30, 0, 0, DateTimeKind.Utc), "Milk, eggs, bread, vegetables, fruits", new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medium", 0, "Buy Groceries" },
                    { 3, 2, new DateTime(2025, 8, 18, 16, 0, 0, 0, DateTimeKind.Utc), "Weekly check-in call with family", new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "High", 2, "Call Mom" },
                    { 4, 1, new DateTime(2025, 8, 20, 9, 0, 0, 0, DateTimeKind.Utc), "Compile sales data and performance metrics", new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "High", 0, "Prepare Quarterly Report" },
                    { 5, 4, new DateTime(2025, 8, 20, 18, 0, 0, 0, DateTimeKind.Utc), "Cardio and strength training session", new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medium", 1, "Gym Workout" },
                    { 6, 5, new DateTime(2025, 8, 15, 11, 0, 0, 0, DateTimeKind.Utc), "Study EF Core relationships and migrations", new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "High", 2, "Learn Entity Framework" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoryId",
                table: "Tasks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Status",
                table: "Tasks",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
