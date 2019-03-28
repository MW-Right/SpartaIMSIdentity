using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartaIMSWebsite.Migrations
{
    public partial class InitialSpartaDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobRoles",
                columns: table => new
                {
                    JobRoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobRoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRoles", x => x.JobRoleID);
                });

            migrationBuilder.CreateTable(
                name: "Specialisations",
                columns: table => new
                {
                    SpecID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialisations", x => x.SpecID);
                });

            migrationBuilder.CreateTable(
                name: "Cohorts",
                columns: table => new
                {
                    CohortID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CohortName = table.Column<string>(nullable: true),
                    SpecID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cohorts", x => x.CohortID);
                    table.ForeignKey(
                        name: "FK_Cohorts_Specialisations_SpecID",
                        column: x => x.SpecID,
                        principalTable: "Specialisations",
                        principalColumn: "SpecID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpartanUsers",
                columns: table => new
                {
                    SpartanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    CohortID = table.Column<int>(nullable: false),
                    JobRoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpartanUsers", x => x.SpartanID);
                    table.ForeignKey(
                        name: "FK_SpartanUsers_Cohorts_CohortID",
                        column: x => x.CohortID,
                        principalTable: "Cohorts",
                        principalColumn: "CohortID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpartanUsers_JobRoles_JobRoleID",
                        column: x => x.JobRoleID,
                        principalTable: "JobRoles",
                        principalColumn: "JobRoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cohorts_SpecID",
                table: "Cohorts",
                column: "SpecID");

            migrationBuilder.CreateIndex(
                name: "IX_SpartanUsers_CohortID",
                table: "SpartanUsers",
                column: "CohortID");

            migrationBuilder.CreateIndex(
                name: "IX_SpartanUsers_JobRoleID",
                table: "SpartanUsers",
                column: "JobRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpartanUsers");

            migrationBuilder.DropTable(
                name: "Cohorts");

            migrationBuilder.DropTable(
                name: "JobRoles");

            migrationBuilder.DropTable(
                name: "Specialisations");
        }
    }
}
