using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerManagement.Migrations
{
    /// <inheritdoc />
    public partial class yun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    ServerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.ServerId);
                });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "ServerId", "City", "IsOnline", "Name" },
                values: new object[,]
                {
                    { 1, "Nashville", true, "Server 1" },
                    { 2, "Nashville", false, "Server 2" },
                    { 3, "Nashville", false, "Server 3" },
                    { 4, "Nashville", true, "Server 4" },
                    { 5, "Nolensville", true, "Server 5" },
                    { 6, "Nolensville", false, "Server 6" },
                    { 7, "Nolensville", true, "Server 7" },
                    { 8, "Franklin", true, "Server 8" },
                    { 9, "Franklin", false, "Server 9" },
                    { 10, "Franklin", false, "Server 10" },
                    { 11, "Franklin", true, "Server 11" },
                    { 12, "Knoxville", false, "Server 12" },
                    { 13, "Knoxville", true, "Server 13" },
                    { 14, "Knoxville", false, "Server 14" },
                    { 15, "Knoxville", true, "Server 15" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
