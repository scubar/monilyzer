using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Monilyzer.API.Migrations
{
    public partial class Alerts_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AlertDefinitions",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    AlertObjectPropertyType = table.Column<int>(nullable: false),
                    AlertObjectType = table.Column<int>(nullable: false),
                    AlertStatusCondition = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EvaluationInterval = table.Column<double>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NextEvaluation = table.Column<DateTime>(nullable: false),
                    Version = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertDefinitions", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ActiveAlerts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    AlertDefinitionGuid = table.Column<Guid>(nullable: false),
                    AlertObjectPropertyType = table.Column<int>(nullable: false),
                    AlertObjectType = table.Column<int>(nullable: false),
                    AlertStatusCondition = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CustomerGuid = table.Column<Guid>(nullable: true),
                    EvaluationInterval = table.Column<double>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LocationGuid = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NextEvaluation = table.Column<DateTime>(nullable: false),
                    NodeGuid = table.Column<Guid>(nullable: true),
                    Version = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveAlerts", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ActiveAlerts_AlertDefinitions_AlertDefinitionGuid",
                        column: x => x.AlertDefinitionGuid,
                        principalTable: "AlertDefinitions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiveAlerts_Customers_CustomerGuid",
                        column: x => x.CustomerGuid,
                        principalTable: "Customers",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActiveAlerts_Locations_LocationGuid",
                        column: x => x.LocationGuid,
                        principalTable: "Locations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActiveAlerts_Nodes_NodeGuid",
                        column: x => x.NodeGuid,
                        principalTable: "Nodes",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveAlerts_AlertDefinitionGuid",
                table: "ActiveAlerts",
                column: "AlertDefinitionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveAlerts_CustomerGuid",
                table: "ActiveAlerts",
                column: "CustomerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveAlerts_LocationGuid",
                table: "ActiveAlerts",
                column: "LocationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveAlerts_NodeGuid",
                table: "ActiveAlerts",
                column: "NodeGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveAlerts");

            migrationBuilder.DropTable(
                name: "AlertDefinitions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customers");
        }
    }
}
