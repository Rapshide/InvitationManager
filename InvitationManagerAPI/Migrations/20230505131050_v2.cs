using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvitationManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefonszám = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    erzekenysegek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vallás = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fogyatékosság = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    titulus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userType = table.Column<int>(type: "int", nullable: false),
                    ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    utolsóesemény = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
