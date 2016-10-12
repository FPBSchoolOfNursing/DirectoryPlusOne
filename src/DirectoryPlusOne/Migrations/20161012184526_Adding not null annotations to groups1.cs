using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectoryPlusOne.Migrations
{
    public partial class Addingnotnullannotationstogroups1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "AdGroupName",
                table: "Groups",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdGroupName",
                table: "Groups",
                nullable: true);
        }
    }
}
