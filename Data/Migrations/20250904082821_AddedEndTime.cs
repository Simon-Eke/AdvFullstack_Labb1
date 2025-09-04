using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvFullstack_Labb1.Migrations
{
    /// <inheritdoc />
    public partial class AddedEndTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Bookings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Bookings");
        }
    }
}
