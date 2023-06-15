using ManagerServer.Database.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManagerServer.Database
{
    public class ManagerDbContext : IdentityDbContext<AppUser>
    {
        public ManagerDbContext(DbContextOptions<ManagerDbContext> options) : base (options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<FarmEntity> ()
        //                .HasOne<AppUser> (s => s.Owner)
        //                .WithMany (g => g.Farms)
        //                .HasForeignKey (s => s.OwnerId);

        //    modelBuilder.Entity<ZoneEntity> ()
        //                .HasOne<FarmEntity> (s => s.Farm)
        //                .WithMany (g => g.Zones)
        //                .HasForeignKey (s => s.FarmId);

        //    modelBuilder.Entity<DeviceActionEntity> ()
        //                .HasOne<ZoneEntity> (s => s.Zone)
        //                .WithMany (g => g.DeviceActions)
        //                .HasForeignKey (s => s.ZoneId);

        //    modelBuilder.Entity<MeasuringDeviceEntity> ()
        //                .HasOne<ZoneEntity> (s => s.Zone)
        //                .WithMany (g => g.MeasuringDevices)
        //                .HasForeignKey (s => s.ZoneId);

        //    modelBuilder.Entity<DeviceActionLogEntity> ()
        //                .HasOne<DeviceActionEntity> (s => s.DeviceAction)
        //                .WithMany (g => g.DeviceActionLog)
        //                .HasForeignKey (s => s.DeviceActionId);
        //    // one to one
        //    modelBuilder.Entity<MeasuringDeviceEntity> ()
        //                .HasOne<DeviceActionLogEntity> (s => s.DeviceActionLog)
        //                .WithOne (g => g.MeasuringDevice)
        //                .HasForeignKey<DeviceActionLogEntity> (s => s.DeviceMeasureId);

        //    modelBuilder.Entity<DataDeviceResponseEntity> ()
        //                .HasOne<MeasuringDeviceEntity> (s => s.MeasuringDevice)
        //                .WithMany (g => g.DataDeviceResponses)
        //                .HasForeignKey (s => s.DataDeviceId);

        //    modelBuilder.Entity<StatisticalDataResponseForHourEntity> ()
        //                .HasOne<MeasuringDeviceEntity> (s => s.StatisticalDataResponse)
        //                .WithMany (g => g.StatisticalDataResponsesForHours)
        //                .HasForeignKey (s => s.DeviceMeasureId);

        //    modelBuilder.Entity<StatisticalDataResponseForDayEntity> ()
        //                .HasOne<MeasuringDeviceEntity> (s => s.StatisticalDataResponse)
        //                .WithMany (g => g.StatisticalDataResponsesForDays)
        //                .HasForeignKey (s => s.DeviceMeasureId);

        //    modelBuilder.Entity<StatisticalDataResponseForWeekEntity> ()
        //                .HasOne<MeasuringDeviceEntity> (s => s.StatisticalDataResponse)
        //                .WithMany (g => g.StatisticalDataResponsesForWeek)
        //                .HasForeignKey (s => s.DeviceMeasureId);

        //    modelBuilder.Entity<StatisticalDataResponseForMonthEntity> ()
        //                .HasOne<MeasuringDeviceEntity> (s => s.StatisticalDataResponse)
        //                .WithMany (g => g.StatisticalDataResponsesForMonth)
        //                .HasForeignKey (s => s.DeviceMeasureId);
        //}
        public DbSet<DataDeviceResponseEntity> DataDeviceResponseEntities { get; set; }
        public DbSet<FarmEntity> FarmEntities { get; set; }
        public DbSet<ZoneEntity> ZoneEntities { get; set; }
        public DbSet<MeasuringDeviceEntity> MeasuringDeviceEntities { get; set; }
        public DbSet<DeviceActionEntity> DeviceActionEntities { get; set; }
        public DbSet<DeviceActionLogEntity> DeviceActionLogEntities { get; set; }
        public DbSet<StatisticalDataResponseForDayEntity> StatisticalDataResponseForDayEntities { get; set; }
        public DbSet<StatisticalDataResponseForHourEntity> StatisticalDataResponseForHourEntities { get; set; }
        public DbSet<StatisticalDataResponseForMonthEntity> StatisticalDataResponseForMonthEntities { get; set; }
        public DbSet<StatisticalDataResponseForWeekEntity> StatisticalDataResponseForWeekEntities { get; set; }
    }
}
