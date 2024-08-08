using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    public partial class AddBangDiemThanhPhan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HocSinhLopHoc",
                table: "HocSinhLopHoc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HocSinhLopHoc",
                table: "HocSinhLopHoc",
                columns: new[] { "lopId", "hocSinhId" });

            migrationBuilder.CreateTable(
                name: "BangDiemThanhPhan",
                columns: table => new
                {
                    HocSinhId = table.Column<int>(type: "int", nullable: false),
                    CotDiemId = table.Column<int>(type: "int", nullable: false),
                    LopId = table.Column<int>(type: "int", nullable: false),
                    Diem = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangDiemThanhPhan", x => new { x.HocSinhId, x.CotDiemId, x.LopId });
                });

            // Xóa dữ liệu trùng lặp nếu tồn tại
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE NormalizedName = 'USER'");
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE NormalizedName = 'ADMIN'");

            // Chỉ chèn dữ liệu nếu chưa tồn tại
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT 1 FROM AspNetRoles WHERE NormalizedName = 'USER')
                BEGIN
                    INSERT INTO AspNetRoles (Id, ConcurrencyStamp, Name, NormalizedName)
                    VALUES ('79525bcf-0785-4155-984f-594087e7dfa4', null, 'User', 'USER')
                END
            ");

            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT 1 FROM AspNetRoles WHERE NormalizedName = 'ADMIN')
                BEGIN
                    INSERT INTO AspNetRoles (Id, ConcurrencyStamp, Name, NormalizedName)
                    VALUES ('905c4a4a-3143-4d72-a203-c40d3812d88c', null, 'Admin', 'ADMIN')
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BangDiemThanhPhan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HocSinhLopHoc",
                table: "HocSinhLopHoc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79525bcf-0785-4155-984f-594087e7dfa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "905c4a4a-3143-4d72-a203-c40d3812d88c");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HocSinhLopHoc",
                table: "HocSinhLopHoc",
                column: "lopId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fac2ff1-9cb4-40a8-933b-04d8e419e3b0", null, "User", "USER" },
                    { "d410b449-1558-47ea-9938-7f03aaccf282", null, "Admin", "ADMIN" }
                });
        }
    }
}
