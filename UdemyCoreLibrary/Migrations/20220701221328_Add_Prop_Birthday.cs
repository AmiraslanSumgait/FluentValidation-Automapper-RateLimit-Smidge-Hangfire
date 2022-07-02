using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCoreLibrary.Migrations
{
    public partial class Add_Prop_Birthday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Customers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Customers");
        }
    }
}
