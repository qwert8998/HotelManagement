﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TzuChing.HotelManagement.Infrastructure.Migrations
{
    public partial class RoomUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Room",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Room",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);
        }
    }
}
