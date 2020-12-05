using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactBook.Api.Migrations
{
    public partial class ProjectSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonContacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    ExtraMobileNo = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContacts", x => x.ContactId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonContacts");
        }
    }
}
