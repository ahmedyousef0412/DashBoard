using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCore.DAL.Migrations
{
    public partial class UploadFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CvUrl",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CvUrl",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Employee");
        }
    }
}
