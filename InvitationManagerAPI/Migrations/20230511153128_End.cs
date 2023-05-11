using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvitationManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class End : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "User",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "PasswordHash");
        }
    }
}
