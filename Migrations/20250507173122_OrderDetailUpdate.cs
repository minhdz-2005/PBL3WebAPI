using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PBL3WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class OrderDetailUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderDetail");
        }
    }
}
