using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TypeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SensorTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Temperature" },
                    { 2L, "Humidity" },
                    { 3L, "Light" },
                    { 4L, "Audio" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
