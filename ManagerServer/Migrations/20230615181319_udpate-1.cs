using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerServer.Migrations
{
    /// <inheritdoc />
    public partial class udpate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "deviceType",
                table: "StatisticalDataResponseForWeekEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "deviceType",
                table: "StatisticalDataResponseForMonthEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "deviceType",
                table: "StatisticalDataResponseForHourEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "deviceType",
                table: "StatisticalDataResponseForDayEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "deviceType",
                table: "MeasuringDeviceEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deviceType",
                table: "StatisticalDataResponseForWeekEntities");

            migrationBuilder.DropColumn(
                name: "deviceType",
                table: "StatisticalDataResponseForMonthEntities");

            migrationBuilder.DropColumn(
                name: "deviceType",
                table: "StatisticalDataResponseForHourEntities");

            migrationBuilder.DropColumn(
                name: "deviceType",
                table: "StatisticalDataResponseForDayEntities");

            migrationBuilder.DropColumn(
                name: "deviceType",
                table: "MeasuringDeviceEntities");
        }
    }
}
