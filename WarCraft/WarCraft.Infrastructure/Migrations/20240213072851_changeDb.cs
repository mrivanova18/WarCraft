using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarCraft.Infrastructure.Migrations
{
    public partial class changeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryOfOrigin",
                table: "Manufacturers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryOfOrigin",
                table: "Manufacturers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
