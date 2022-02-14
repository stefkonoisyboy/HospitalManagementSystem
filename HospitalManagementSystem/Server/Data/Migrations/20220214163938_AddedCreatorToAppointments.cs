using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.Server.Data.Migrations
{
    public partial class AddedCreatorToAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CreatorId",
                table: "Appointments",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_CreatorId",
                table: "Appointments",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_CreatorId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CreatorId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Appointments");
        }
    }
}
