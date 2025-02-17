using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GetriWebApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateActivityTableWithDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[,]
                {
                    { new Guid("13d5fd5b-5168-49cf-b8b6-a79fd6d65457"), "Music", "New York", new DateTime(2025, 5, 15, 19, 30, 0, 0, DateTimeKind.Unspecified), "Join us for an unforgettable night of classic rock music with top bands.", "Music Concert: Rock Legends", "Madison Square Garden" },
                    { new Guid("7f1d989e-c19a-4445-91c2-1f4e22cb2805"), "Art", "San Francisco", new DateTime(2025, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Explore the world of contemporary art with works from renowned artists.", "Art Exhibition: Modern Masterpieces", "SFMOMA" },
                    { new Guid("b9ff0b3b-832f-4ea1-b835-b58a68e39531"), "Technology", "Chicago", new DateTime(2025, 7, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "A deep dive into the latest trends and innovations in artificial intelligence.", "Tech Conference: Future of AI", "McCormick Place" },
                    { new Guid("cb40a1ea-5df7-4f7b-a154-5a4caecd3c5e"), "Food", "Los Angeles", new DateTime(2025, 8, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), "Savor authentic Italian dishes from the best chefs and local vendors.", "Food Festival: Taste of Italy", "Los Angeles Convention Center" },
                    { new Guid("d8c14150-874b-4e2e-b069-2b154f7f74bb"), "Fitness", "Miami", new DateTime(2025, 6, 10, 6, 0, 0, 0, DateTimeKind.Unspecified), "Get in shape this summer with an intensive bootcamp that will push your limits.", "Fitness Bootcamp: Summer Challenge", "South Beach" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");
        }
    }
}
