using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemeLib.DbContext.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "memes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Meme Id"),
                    alias = table.Column<string>(type: "text", nullable: false, comment: "Meme Alias"),
                    ts = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Meme last update timestamp"),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Meme's author id"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "Meme description"),
                    publish_date = table.Column<DateOnly>(type: "date", nullable: false, comment: "Meme publish date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memes", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "memes");
        }
    }
}
