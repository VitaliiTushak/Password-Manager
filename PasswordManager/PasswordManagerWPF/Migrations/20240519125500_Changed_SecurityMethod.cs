using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordManagerWPF.Migrations
{
    /// <inheritdoc />
    public partial class Changed_SecurityMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EncryptionMethods",
                table: "EncryptionMethods");

            migrationBuilder.RenameTable(
                name: "EncryptionMethods",
                newName: "SecurityMethods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecurityMethods",
                table: "SecurityMethods",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SecurityMethods",
                table: "SecurityMethods");

            migrationBuilder.RenameTable(
                name: "SecurityMethods",
                newName: "EncryptionMethods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EncryptionMethods",
                table: "EncryptionMethods",
                column: "Id");
        }
    }
}
