using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerServer.Migrations
{
    /// <inheritdoc />
    public partial class changeNameFKEntityMeasuring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasuringDeviceEntities_DeviceActionLogEntities_DataDeviceResponsesId",
                table: "MeasuringDeviceEntities");

            migrationBuilder.RenameColumn(
                name: "DataDeviceResponsesId",
                table: "MeasuringDeviceEntities",
                newName: "DeviceActionLogId");

            migrationBuilder.RenameIndex(
                name: "IX_MeasuringDeviceEntities_DataDeviceResponsesId",
                table: "MeasuringDeviceEntities",
                newName: "IX_MeasuringDeviceEntities_DeviceActionLogId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValueDate",
                table: "StatisticalDataResponseForDayEntities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "TotalValue",
                table: "StatisticalDataResponseForDayEntities",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ToDate",
                table: "StatisticalDataResponseForDayEntities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "MinValue",
                table: "StatisticalDataResponseForDayEntities",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "MaxValue",
                table: "StatisticalDataResponseForDayEntities",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FromDate",
                table: "StatisticalDataResponseForDayEntities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRetrive",
                table: "StatisticalDataResponseForDayEntities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "AvgValue",
                table: "StatisticalDataResponseForDayEntities",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasuringDeviceEntities_DeviceActionLogEntities_DeviceActionLogId",
                table: "MeasuringDeviceEntities",
                column: "DeviceActionLogId",
                principalTable: "DeviceActionLogEntities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasuringDeviceEntities_DeviceActionLogEntities_DeviceActionLogId",
                table: "MeasuringDeviceEntities");

            migrationBuilder.RenameColumn(
                name: "DeviceActionLogId",
                table: "MeasuringDeviceEntities",
                newName: "DataDeviceResponsesId");

            migrationBuilder.RenameIndex(
                name: "IX_MeasuringDeviceEntities_DeviceActionLogId",
                table: "MeasuringDeviceEntities",
                newName: "IX_MeasuringDeviceEntities_DataDeviceResponsesId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValueDate",
                table: "StatisticalDataResponseForDayEntities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalValue",
                table: "StatisticalDataResponseForDayEntities",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ToDate",
                table: "StatisticalDataResponseForDayEntities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MinValue",
                table: "StatisticalDataResponseForDayEntities",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MaxValue",
                table: "StatisticalDataResponseForDayEntities",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FromDate",
                table: "StatisticalDataResponseForDayEntities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRetrive",
                table: "StatisticalDataResponseForDayEntities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AvgValue",
                table: "StatisticalDataResponseForDayEntities",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MeasuringDeviceEntities_DeviceActionLogEntities_DataDeviceResponsesId",
                table: "MeasuringDeviceEntities",
                column: "DataDeviceResponsesId",
                principalTable: "DeviceActionLogEntities",
                principalColumn: "Id");
        }
    }
}
