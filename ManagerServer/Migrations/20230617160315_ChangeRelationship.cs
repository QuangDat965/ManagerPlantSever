using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerServer.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceActionLogEntities_MeasuringDeviceEntities_DeviceMeasureId",
                table: "DeviceActionLogEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_MeasuringDeviceEntities_DeviceActionLogEntities_DeviceActionLogId",
                table: "MeasuringDeviceEntities");

            migrationBuilder.DropTable(
                name: "StatisticalDataResponseForDayEntities");

            migrationBuilder.DropTable(
                name: "StatisticalDataResponseForMonthEntities");

            migrationBuilder.DropTable(
                name: "StatisticalDataResponseForWeekEntities");

            migrationBuilder.DropIndex(
                name: "IX_MeasuringDeviceEntities_DeviceActionLogId",
                table: "MeasuringDeviceEntities");

            migrationBuilder.DropIndex(
                name: "IX_DeviceActionLogEntities_DeviceMeasureId",
                table: "DeviceActionLogEntities");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "StatisticalDataResponseForHourEntities");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "StatisticalDataResponseForHourEntities");

            migrationBuilder.DropColumn(
                name: "DeviceActionLogId",
                table: "MeasuringDeviceEntities");

            migrationBuilder.DropColumn(
                name: "DeviceMeasureId",
                table: "DeviceActionLogEntities");

            migrationBuilder.RenameColumn(
                name: "deviceType",
                table: "StatisticalDataResponseForHourEntities",
                newName: "DeviceType");

            migrationBuilder.RenameColumn(
                name: "deviceType",
                table: "MeasuringDeviceEntities",
                newName: "DeviceType");

            migrationBuilder.RenameColumn(
                name: "ValueDeviceMeasure",
                table: "DeviceActionLogEntities",
                newName: "ValueMin");

            migrationBuilder.RenameColumn(
                name: "NumberChangeAuto",
                table: "DeviceActionLogEntities",
                newName: "NumberMinChangeAuto");

            migrationBuilder.AddColumn<bool>(
                name: "NumberMaxChangeAuto",
                table: "DeviceActionLogEntities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "ValueMax",
                table: "DeviceActionLogEntities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberMaxChangeAuto",
                table: "DeviceActionLogEntities");

            migrationBuilder.DropColumn(
                name: "ValueMax",
                table: "DeviceActionLogEntities");

            migrationBuilder.RenameColumn(
                name: "DeviceType",
                table: "StatisticalDataResponseForHourEntities",
                newName: "deviceType");

            migrationBuilder.RenameColumn(
                name: "DeviceType",
                table: "MeasuringDeviceEntities",
                newName: "deviceType");

            migrationBuilder.RenameColumn(
                name: "ValueMin",
                table: "DeviceActionLogEntities",
                newName: "ValueDeviceMeasure");

            migrationBuilder.RenameColumn(
                name: "NumberMinChangeAuto",
                table: "DeviceActionLogEntities",
                newName: "NumberChangeAuto");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "StatisticalDataResponseForHourEntities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "StatisticalDataResponseForHourEntities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeviceActionLogId",
                table: "MeasuringDeviceEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceMeasureId",
                table: "DeviceActionLogEntities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StatisticalDataResponseForDayEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvgValue = table.Column<double>(type: "float", nullable: true),
                    DateRetrive = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeviceMeasureId = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaxValue = table.Column<double>(type: "float", nullable: true),
                    MeasuringDeviceEntityId = table.Column<int>(type: "int", nullable: true),
                    MinValue = table.Column<double>(type: "float", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalValue = table.Column<double>(type: "float", nullable: true),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deviceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticalDataResponseForDayEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticalDataResponseForDayEntities_MeasuringDeviceEntities_MeasuringDeviceEntityId",
                        column: x => x.MeasuringDeviceEntityId,
                        principalTable: "MeasuringDeviceEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatisticalDataResponseForMonthEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvgValue = table.Column<double>(type: "float", nullable: false),
                    DateRetrive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceMeasureId = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    MeasuringDeviceEntityId = table.Column<int>(type: "int", nullable: true),
                    MinValue = table.Column<double>(type: "float", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalValue = table.Column<double>(type: "float", nullable: false),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deviceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticalDataResponseForMonthEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticalDataResponseForMonthEntities_MeasuringDeviceEntities_MeasuringDeviceEntityId",
                        column: x => x.MeasuringDeviceEntityId,
                        principalTable: "MeasuringDeviceEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatisticalDataResponseForWeekEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvgValue = table.Column<double>(type: "float", nullable: false),
                    DateRetrive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceMeasureId = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    MeasuringDeviceEntityId = table.Column<int>(type: "int", nullable: true),
                    MinValue = table.Column<double>(type: "float", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalValue = table.Column<double>(type: "float", nullable: false),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deviceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticalDataResponseForWeekEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticalDataResponseForWeekEntities_MeasuringDeviceEntities_MeasuringDeviceEntityId",
                        column: x => x.MeasuringDeviceEntityId,
                        principalTable: "MeasuringDeviceEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeasuringDeviceEntities_DeviceActionLogId",
                table: "MeasuringDeviceEntities",
                column: "DeviceActionLogId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceActionLogEntities_DeviceMeasureId",
                table: "DeviceActionLogEntities",
                column: "DeviceMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticalDataResponseForDayEntities_MeasuringDeviceEntityId",
                table: "StatisticalDataResponseForDayEntities",
                column: "MeasuringDeviceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticalDataResponseForMonthEntities_MeasuringDeviceEntityId",
                table: "StatisticalDataResponseForMonthEntities",
                column: "MeasuringDeviceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticalDataResponseForWeekEntities_MeasuringDeviceEntityId",
                table: "StatisticalDataResponseForWeekEntities",
                column: "MeasuringDeviceEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceActionLogEntities_MeasuringDeviceEntities_DeviceMeasureId",
                table: "DeviceActionLogEntities",
                column: "DeviceMeasureId",
                principalTable: "MeasuringDeviceEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasuringDeviceEntities_DeviceActionLogEntities_DeviceActionLogId",
                table: "MeasuringDeviceEntities",
                column: "DeviceActionLogId",
                principalTable: "DeviceActionLogEntities",
                principalColumn: "Id");
        }
    }
}
