using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectoryPlusOne.Migrations
{
    public partial class AddingSubgroupandAdGrouptoGroupEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdGroupName",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubGroupName",
                table: "Groups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdGroupName",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SubGroupName",
                table: "Groups");
        }
    }
}
