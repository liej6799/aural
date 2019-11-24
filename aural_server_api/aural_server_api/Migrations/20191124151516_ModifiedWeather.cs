using Microsoft.EntityFrameworkCore.Migrations;

namespace aural_server_api.Migrations
{
    public partial class ModifiedWeather : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityAPIId",
                table: "CityModels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityAPIId",
                table: "CityModels");
        }
    }
}
