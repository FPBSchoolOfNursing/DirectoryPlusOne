using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DirectoryPlusOne.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Building = table.Column<string>(nullable: true),
                    Elevation = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    RoomNumber = table.Column<string>(nullable: true),
                    SquareFeet = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    CaseUserID = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    HomePageURL = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    Suffix = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.CaseUserID);
                });

            migrationBuilder.CreateTable(
                name: "PersonGroup",
                columns: table => new
                {
                    CaseUserID = table.Column<string>(nullable: false),
                    GroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGroup", x => new { x.CaseUserID, x.GroupID });
                    table.ForeignKey(
                        name: "FK_PersonGroup_Person_CaseUserID",
                        column: x => x.CaseUserID,
                        principalTable: "Person",
                        principalColumn: "CaseUserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonGroup_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonOffice",
                columns: table => new
                {
                    CaseUserID = table.Column<string>(nullable: false),
                    OfficeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonOffice", x => new { x.CaseUserID, x.OfficeID });
                    table.ForeignKey(
                        name: "FK_PersonOffice_Person_CaseUserID",
                        column: x => x.CaseUserID,
                        principalTable: "Person",
                        principalColumn: "CaseUserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonOffice_Offices_OfficeID",
                        column: x => x.OfficeID,
                        principalTable: "Offices",
                        principalColumn: "OfficeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRole",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseUserID = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRole", x => x.RoleID);
                    table.ForeignKey(
                        name: "FK_PersonRole_Person_CaseUserID",
                        column: x => x.CaseUserID,
                        principalTable: "Person",
                        principalColumn: "CaseUserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonGroup_CaseUserID",
                table: "PersonGroup",
                column: "CaseUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGroup_GroupID",
                table: "PersonGroup",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonOffice_CaseUserID",
                table: "PersonOffice",
                column: "CaseUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonOffice_OfficeID",
                table: "PersonOffice",
                column: "OfficeID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_CaseUserID",
                table: "PersonRole",
                column: "CaseUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonGroup");

            migrationBuilder.DropTable(
                name: "PersonOffice");

            migrationBuilder.DropTable(
                name: "PersonRole");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
