using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartaIMSWebsite.Migrations
{
    public partial class cohorts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cohorts_Specialisations_SpecialisationSpecID",
                table: "Cohorts");

            migrationBuilder.DropIndex(
                name: "IX_Cohorts_SpecialisationSpecID",
                table: "Cohorts");

            migrationBuilder.DropColumn(
                name: "SpecialisationSpecID",
                table: "Cohorts");

            migrationBuilder.AddColumn<int>(
                name: "SpecID",
                table: "Cohorts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cohorts_SpecID",
                table: "Cohorts",
                column: "SpecID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cohorts_Specialisations_SpecID",
                table: "Cohorts",
                column: "SpecID",
                principalTable: "Specialisations",
                principalColumn: "SpecID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cohorts_Specialisations_SpecID",
                table: "Cohorts");

            migrationBuilder.DropIndex(
                name: "IX_Cohorts_SpecID",
                table: "Cohorts");

            migrationBuilder.DropColumn(
                name: "SpecID",
                table: "Cohorts");

            migrationBuilder.AddColumn<int>(
                name: "SpecialisationSpecID",
                table: "Cohorts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cohorts_SpecialisationSpecID",
                table: "Cohorts",
                column: "SpecialisationSpecID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cohorts_Specialisations_SpecialisationSpecID",
                table: "Cohorts",
                column: "SpecialisationSpecID",
                principalTable: "Specialisations",
                principalColumn: "SpecID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
