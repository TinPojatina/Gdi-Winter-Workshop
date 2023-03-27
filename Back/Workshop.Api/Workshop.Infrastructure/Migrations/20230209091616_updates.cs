using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SensorSerial",
                table: "Sensors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SensorSerial",
                table: "Sensors");
        }
    }
}
