using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InfrastructureLayer.Migrations
{
    public partial class InitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("6fc7825d-9965-47a5-b892-9ddae2929480"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("fb32f25d-26e7-4224-8879-9045a6b5230c"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("b77c2555-c196-42f2-8ce0-83fd53c82dd9"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("d36d70e7-5591-4a6b-b27f-cf3dd85dc2c5"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("a8a2146e-e3dc-40d3-ab58-2815205ba9c1"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GuId",
                value: new Guid("be3d9955-fe14-459e-b80a-d1626b9442cb"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GuId",
                value: new Guid("437a0da2-6799-4f3c-8d87-a08738b7605b"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "GuId",
                value: new Guid("1b4eb4e3-56af-4e9d-8342-90dc98a146e9"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "GuId",
                value: new Guid("37c5c837-7512-4e4f-a7b6-93db19e6158c"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("6fc7825d-9965-47a5-b892-9ddae2929480"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("fb32f25d-26e7-4224-8879-9045a6b5230c"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("b77c2555-c196-42f2-8ce0-83fd53c82dd9"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("d36d70e7-5591-4a6b-b27f-cf3dd85dc2c5"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("a8a2146e-e3dc-40d3-ab58-2815205ba9c1"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "GuId",
                value: new Guid("be3d9955-fe14-459e-b80a-d1626b9442cb"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "GuId",
                value: new Guid("437a0da2-6799-4f3c-8d87-a08738b7605b"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "GuId",
                value: new Guid("1b4eb4e3-56af-4e9d-8342-90dc98a146e9"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "GuId",
                value: new Guid("37c5c837-7512-4e4f-a7b6-93db19e6158c"));
        }
    }
}
