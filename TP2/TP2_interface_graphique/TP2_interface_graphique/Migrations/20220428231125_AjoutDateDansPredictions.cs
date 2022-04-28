using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP2_interface_graphique.Migrations
{
    public partial class AjoutDateDansPredictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePrediction",
                table: "Predictions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePrediction",
                table: "Predictions");
        }
    }
}
