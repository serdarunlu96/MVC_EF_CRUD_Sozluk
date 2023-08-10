using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCrudCalisma.Data.Migrations
{
    /// <inheritdoc />
    public partial class Ilk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Girdiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sozcuk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anlam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Girdiler", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Girdiler",
                columns: new[] { "Id", "Anlam", "Sozcuk" },
                values: new object[,]
                {
                    { 1, "Kitap", "Book" },
                    { 2, "Bilgisayar", "Computer" },
                    { 3, "Güneş", "Sun" },
                    { 4, "Araba", "Car" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Girdiler");
        }
    }
}
