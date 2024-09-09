using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarLab.Academy.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class Add_Disabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disabled",
                table: "Advert",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disabled",
                table: "Advert");
        }
    }
}
