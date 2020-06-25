using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalOwl.Migrations.Migrations
{
    public partial class _0003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupRoleId",
                table: "GroupMembers",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_GroupRoleId",
                table: "GroupMembers",
                column: "GroupRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_GroupRoles_GroupRoleId",
                table: "GroupMembers",
                column: "GroupRoleId",
                principalTable: "GroupRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_GroupRoles_GroupRoleId",
                table: "GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_GroupMembers_GroupRoleId",
                table: "GroupMembers");

            migrationBuilder.DropColumn(
                name: "GroupRoleId",
                table: "GroupMembers");

            migrationBuilder.UpdateData(
                table: "GroupPolices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 12, 11, 960, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "GroupPolices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 12, 11, 960, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "GroupPolices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 12, 11, 960, DateTimeKind.Utc).AddTicks(6108));

            migrationBuilder.UpdateData(
                table: "GroupPolices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 12, 11, 960, DateTimeKind.Utc).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "GroupRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 12, 11, 960, DateTimeKind.Utc).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "GroupRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 12, 11, 960, DateTimeKind.Utc).AddTicks(9906));

            migrationBuilder.UpdateData(
                table: "GroupRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 6, 25, 14, 12, 11, 960, DateTimeKind.Utc).AddTicks(9941));
        }
    }
}
