using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Country__3214EC074152CF1D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Group__3214EC0765C96CDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LanguageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Language__3214EC075286E56D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Password = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Login__3214EC077E08E475", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Status__3214EC0787C6676E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    building = table.Column<int>(type: "int", nullable: true),
                    Appartment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Address_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Phone = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    LastCall = table.Column<DateTime>(type: "datetime", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    PrayerName = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Contacts_Group",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Language",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Status",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AddressId",
                table: "Contacts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_GroupId",
                table: "Contacts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LanguageId",
                table: "Contacts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_StatusId",
                table: "Contacts",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
