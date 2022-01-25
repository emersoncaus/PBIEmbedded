using Microsoft.EntityFrameworkCore.Migrations;

namespace PBIEmbedded.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dashboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Report_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicePrincipals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SP_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecretID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePrincipals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardServicePrincipals",
                columns: table => new
                {
                    DashboardId = table.Column<int>(type: "int", nullable: false),
                    ServicePrincipalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardServicePrincipals", x => new { x.DashboardId, x.ServicePrincipalId });
                    table.ForeignKey(
                        name: "FK_DashboardServicePrincipals_Dashboards_DashboardId",
                        column: x => x.DashboardId,
                        principalTable: "Dashboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DashboardServicePrincipals_ServicePrincipals_ServicePrincipalId",
                        column: x => x.ServicePrincipalId,
                        principalTable: "ServicePrincipals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePrincipalUsers",
                columns: table => new
                {
                    ServicePrincipalId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePrincipalUsers", x => new { x.UserId, x.ServicePrincipalId });
                    table.ForeignKey(
                        name: "FK_ServicePrincipalUsers_ServicePrincipals_ServicePrincipalId",
                        column: x => x.ServicePrincipalId,
                        principalTable: "ServicePrincipals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicePrincipalUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DashboardServicePrincipals_ServicePrincipalId",
                table: "DashboardServicePrincipals",
                column: "ServicePrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePrincipalUsers_ServicePrincipalId",
                table: "ServicePrincipalUsers",
                column: "ServicePrincipalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashboardServicePrincipals");

            migrationBuilder.DropTable(
                name: "ServicePrincipalUsers");

            migrationBuilder.DropTable(
                name: "Dashboards");

            migrationBuilder.DropTable(
                name: "ServicePrincipals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
