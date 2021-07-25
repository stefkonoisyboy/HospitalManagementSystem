using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.Server.Data.Migrations
{
    public partial class AddedOtherInfoToPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherInformation",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherInformation",
                table: "Payments");
        }
    }
}
