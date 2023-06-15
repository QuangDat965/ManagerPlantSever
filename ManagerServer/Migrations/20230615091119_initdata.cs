using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerServer.Migrations
{
    /// <inheritdoc />
    public partial class initdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Avata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_ative = table.Column<bool>(type: "bit", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmEntities_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ZoneEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FarmEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZoneEntities_FarmEntities_FarmEntityId",
                        column: x => x.FarmEntityId,
                        principalTable: "FarmEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeviceActionEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProblem = table.Column<bool>(type: "bit", nullable: false),
                    IsAction = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    ZoneEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceActionEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceActionEntities_ZoneEntities_ZoneEntityId",
                        column: x => x.ZoneEntityId,
                        principalTable: "ZoneEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataDeviceResponseEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeRetrieve = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeviceId = table.Column<int>(type: "int", nullable: true),
                    MeasuringDeviceEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataDeviceResponseEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceActionLogEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceActionId = table.Column<int>(type: "int", nullable: true),
                    DeviceMeasureId = table.Column<int>(type: "int", nullable: true),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValueDeviceMeasure = table.Column<double>(type: "float", nullable: false),
                    IsAuto = table.Column<bool>(type: "bit", nullable: false),
                    NumberChangeAuto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceActionLogEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceActionLogEntities_DeviceActionEntities_DeviceActionId",
                        column: x => x.DeviceActionId,
                        principalTable: "DeviceActionEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeasuringDeviceEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsProblem = table.Column<bool>(type: "bit", nullable: true),
                    DataDeviceResponsesId = table.Column<int>(type: "int", nullable: true),
                    ZoneEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuringDeviceEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasuringDeviceEntities_DeviceActionLogEntities_DataDeviceResponsesId",
                        column: x => x.DataDeviceResponsesId,
                        principalTable: "DeviceActionLogEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MeasuringDeviceEntities_ZoneEntities_ZoneEntityId",
                        column: x => x.ZoneEntityId,
                        principalTable: "ZoneEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatisticalDataResponseForDayEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceMeasureId = table.Column<int>(type: "int", nullable: true),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvgValue = table.Column<double>(type: "float", nullable: false),
                    MinValue = table.Column<double>(type: "float", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    TotalValue = table.Column<double>(type: "float", nullable: false),
                    DateRetrive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeasuringDeviceEntityId = table.Column<int>(type: "int", nullable: true)
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
                name: "StatisticalDataResponseForHourEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceMeasureId = table.Column<int>(type: "int", nullable: true),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvgValue = table.Column<double>(type: "float", nullable: false),
                    MinValue = table.Column<double>(type: "float", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    TotalValue = table.Column<double>(type: "float", nullable: false),
                    DateRetrive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeasuringDeviceEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticalDataResponseForHourEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticalDataResponseForHourEntities_MeasuringDeviceEntities_MeasuringDeviceEntityId",
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
                    DeviceMeasureId = table.Column<int>(type: "int", nullable: true),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvgValue = table.Column<double>(type: "float", nullable: false),
                    MinValue = table.Column<double>(type: "float", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    TotalValue = table.Column<double>(type: "float", nullable: false),
                    DateRetrive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeasuringDeviceEntityId = table.Column<int>(type: "int", nullable: true)
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
                    DeviceMeasureId = table.Column<int>(type: "int", nullable: true),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvgValue = table.Column<double>(type: "float", nullable: false),
                    MinValue = table.Column<double>(type: "float", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    TotalValue = table.Column<double>(type: "float", nullable: false),
                    DateRetrive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeasuringDeviceEntityId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DataDeviceResponseEntities_MeasuringDeviceEntityId",
                table: "DataDeviceResponseEntities",
                column: "MeasuringDeviceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceActionEntities_ZoneEntityId",
                table: "DeviceActionEntities",
                column: "ZoneEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceActionLogEntities_DeviceActionId",
                table: "DeviceActionLogEntities",
                column: "DeviceActionId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceActionLogEntities_DeviceMeasureId",
                table: "DeviceActionLogEntities",
                column: "DeviceMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmEntities_AppUserId",
                table: "FarmEntities",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuringDeviceEntities_DataDeviceResponsesId",
                table: "MeasuringDeviceEntities",
                column: "DataDeviceResponsesId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuringDeviceEntities_ZoneEntityId",
                table: "MeasuringDeviceEntities",
                column: "ZoneEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticalDataResponseForDayEntities_MeasuringDeviceEntityId",
                table: "StatisticalDataResponseForDayEntities",
                column: "MeasuringDeviceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticalDataResponseForHourEntities_MeasuringDeviceEntityId",
                table: "StatisticalDataResponseForHourEntities",
                column: "MeasuringDeviceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticalDataResponseForMonthEntities_MeasuringDeviceEntityId",
                table: "StatisticalDataResponseForMonthEntities",
                column: "MeasuringDeviceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticalDataResponseForWeekEntities_MeasuringDeviceEntityId",
                table: "StatisticalDataResponseForWeekEntities",
                column: "MeasuringDeviceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneEntities_FarmEntityId",
                table: "ZoneEntities",
                column: "FarmEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataDeviceResponseEntities_MeasuringDeviceEntities_MeasuringDeviceEntityId",
                table: "DataDeviceResponseEntities",
                column: "MeasuringDeviceEntityId",
                principalTable: "MeasuringDeviceEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceActionLogEntities_MeasuringDeviceEntities_DeviceMeasureId",
                table: "DeviceActionLogEntities",
                column: "DeviceMeasureId",
                principalTable: "MeasuringDeviceEntities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmEntities_AspNetUsers_AppUserId",
                table: "FarmEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceActionLogEntities_MeasuringDeviceEntities_DeviceMeasureId",
                table: "DeviceActionLogEntities");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DataDeviceResponseEntities");

            migrationBuilder.DropTable(
                name: "StatisticalDataResponseForDayEntities");

            migrationBuilder.DropTable(
                name: "StatisticalDataResponseForHourEntities");

            migrationBuilder.DropTable(
                name: "StatisticalDataResponseForMonthEntities");

            migrationBuilder.DropTable(
                name: "StatisticalDataResponseForWeekEntities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MeasuringDeviceEntities");

            migrationBuilder.DropTable(
                name: "DeviceActionLogEntities");

            migrationBuilder.DropTable(
                name: "DeviceActionEntities");

            migrationBuilder.DropTable(
                name: "ZoneEntities");

            migrationBuilder.DropTable(
                name: "FarmEntities");
        }
    }
}
