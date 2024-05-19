using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordManagerWPF.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
