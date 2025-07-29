using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class columncreditBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79525bcf-0785-4155-984f-594087e7dfa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "905c4a4a-3143-4d72-a203-c40d3812d88c");

            migrationBuilder.AddColumn<decimal>(
                name: "creditBalance",
                table: "User",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00dfc73e-8aa7-456a-ada9-3870856f4147", null, "User", "USER" },
                    { "cad3812f-4139-4025-aafa-52fa8b91a731", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00dfc73e-8aa7-456a-ada9-3870856f4147");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cad3812f-4139-4025-aafa-52fa8b91a731");

            migrationBuilder.DropColumn(
                name: "creditBalance",
                table: "User");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79525bcf-0785-4155-984f-594087e7dfa4", null, "User", "USER" },
                    { "905c4a4a-3143-4d72-a203-c40d3812d88c", null, "Admin", "ADMIN" }
                });
        }
    }
}
