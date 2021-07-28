using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.Server.Data.Migrations
{
    public partial class AddedQuantityToBloodType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BloodTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BloodTypes");
        }
    }
}
