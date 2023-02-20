using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTechnic_Case.DataAcess.Migrations
{
    public partial class shift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShiftName",
                table: "Shifts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftName",
                table: "Shifts");
        }
    }
}
