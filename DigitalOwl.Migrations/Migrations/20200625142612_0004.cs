using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalOwl.Migrations.Migrations
{
    public partial class _0004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroupPolices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 26, 11, 778, DateTimeKind.Utc).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "GroupPolices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 26, 11, 778, DateTimeKind.Utc).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "GroupPolices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 26, 11, 778, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "GroupPolices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 26, 11, 778, DateTimeKind.Utc).AddTicks(9529));

            migrationBuilder.UpdateData(
                table: "GroupRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 26, 11, 779, DateTimeKind.Utc).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "GroupRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 26, 11, 779, DateTimeKind.Utc).AddTicks(1522));

            migrationBuilder.UpdateData(
                table: "GroupRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 26, 11, 779, DateTimeKind.Utc).AddTicks(1550));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GroupPolices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 24, 24, 979, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "GroupPolices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 24, 24, 979, DateTimeKind.Utc).AddTicks(1828));

            migrationBuilder.UpdateData(
                table: "GroupPolices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 24, 24, 979, DateTimeKind.Utc).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "GroupPolices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 24, 24, 979, DateTimeKind.Utc).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "GroupRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 24, 24, 979, DateTimeKind.Utc).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "GroupRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 24, 24, 979, DateTimeKind.Utc).AddTicks(3876));

            migrationBuilder.UpdateData(
                table: "GroupRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 24, 24, 979, DateTimeKind.Utc).AddTicks(3904));
        }
    }
}
