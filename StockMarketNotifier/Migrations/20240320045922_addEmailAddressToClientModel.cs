﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarketNotifier.Migrations
{
    public partial class addEmailAddressToClientModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "clients");
        }
    }
}
