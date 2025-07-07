using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission.Entities.Migrations
{
    /// <inheritdoc />
    public partial class updatedtaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "email_address", "password" },
                values: new object[] { "admin@gmail.com", "Gmail@123" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                column: "email_address",
                value: "john@ex.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "email_address", "password" },
                values: new object[] { "admin@tatvasoft.com", "Tatva@123" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 2,
                column: "email_address",
                value: "john.doe@example.com");
        }
    }
}
