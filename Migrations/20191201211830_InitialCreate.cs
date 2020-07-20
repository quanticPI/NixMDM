using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NixMdm.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IMEI = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    OsVersion = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");
        }
    }
}
