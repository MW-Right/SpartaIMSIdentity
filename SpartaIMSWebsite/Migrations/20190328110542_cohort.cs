using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartaIMSWebsite.Migrations
{
    public partial class cohort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CohortNumber",
                table: "Cohorts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CohortNumber",
                table: "Cohorts",
                nullable: false,
                defaultValue: 0);
        }
    }
}
