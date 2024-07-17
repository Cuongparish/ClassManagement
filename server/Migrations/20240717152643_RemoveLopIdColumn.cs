using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLopIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49849d33-20f6-4877-84df-e2f9657934c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edbc78b5-fd0e-4024-9a4a-8279743062df");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            // Xóa ràng buộc và cột lopId từ bảng GiaoVienLopHoc
            migrationBuilder.DropPrimaryKey(
                name: "PK_GiaoVienLopHoc",
                table: "GiaoVienLopHoc");

            migrationBuilder.DropColumn(
                name: "lopId",
                table: "GiaoVienLopHoc");

            migrationBuilder.AddColumn<int>(
                name: "lopId",
                table: "GiaoVienLopHoc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiaoVienLopHoc",
                table: "GiaoVienLopHoc",
                column: "lopId");

            // Xóa ràng buộc và cột lopId từ bảng HocSinhLopHoc
            migrationBuilder.DropPrimaryKey(
                name: "PK_HocSinhLopHoc",
                table: "HocSinhLopHoc");

            migrationBuilder.DropColumn(
                name: "lopId",
                table: "HocSinhLopHoc");

            migrationBuilder.AddColumn<int>(
                name: "lopId",
                table: "HocSinhLopHoc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HocSinhLopHoc",
                table: "HocSinhLopHoc",
                column: "lopId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84850feb-3ba4-4478-9a14-83478d35ba15", null, "User", "USER" },
                    { "981d3bbb-6e3c-48a5-a7c0-f864282b7015", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84850feb-3ba4-4478-9a14-83478d35ba15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "981d3bbb-6e3c-48a5-a7c0-f864282b7015");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Khôi phục lại cột lopId với thuộc tính IDENTITY
            migrationBuilder.DropPrimaryKey(
                name: "PK_GiaoVienLopHoc",
                table: "GiaoVienLopHoc");

            migrationBuilder.DropColumn(
                name: "lopId",
                table: "GiaoVienLopHoc");

            migrationBuilder.AddColumn<int>(
                name: "lopId",
                table: "GiaoVienLopHoc",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiaoVienLopHoc",
                table: "GiaoVienLopHoc",
                column: "lopId");

            // Khôi phục lại cột lopId với thuộc tính IDENTITY cho bảng HocSinhLopHoc
            migrationBuilder.DropPrimaryKey(
                name: "PK_HocSinhLopHoc",
                table: "HocSinhLopHoc");

            migrationBuilder.DropColumn(
                name: "lopId",
                table: "HocSinhLopHoc");

            migrationBuilder.AddColumn<int>(
                name: "lopId",
                table: "HocSinhLopHoc",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HocSinhLopHoc",
                table: "HocSinhLopHoc",
                column: "lopId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49849d33-20f6-4877-84df-e2f9657934c9", null, "User", "USER" },
                    { "edbc78b5-fd0e-4024-9a4a-8279743062df", null, "Admin", "ADMIN" }
                });
        }
    }
}
