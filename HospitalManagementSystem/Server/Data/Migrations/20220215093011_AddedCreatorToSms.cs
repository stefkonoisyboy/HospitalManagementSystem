using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.Server.Data.Migrations
{
    public partial class AddedCreatorToSms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "SmsMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "SmsMessages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "SmsMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SmsMessages_CreatorId",
                table: "SmsMessages",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SmsMessages_AspNetUsers_CreatorId",
                table: "SmsMessages",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmsMessages_AspNetUsers_CreatorId",
                table: "SmsMessages");

            migrationBuilder.DropIndex(
                name: "IX_SmsMessages_CreatorId",
                table: "SmsMessages");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "SmsMessages");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "SmsMessages");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "SmsMessages");
        }
    }
}
