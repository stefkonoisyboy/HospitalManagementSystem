using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.Server.Data.Migrations
{
    public partial class AddedPriceAndImageToBeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PricePerDay",
                table: "Beds",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "RemoteImageUrl",
                table: "Beds",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "RemoteImageUrl",
                table: "Beds");
        }
    }
}
