﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PBL3WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addNoteOrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "OrderDetail");
        }
    }
}
