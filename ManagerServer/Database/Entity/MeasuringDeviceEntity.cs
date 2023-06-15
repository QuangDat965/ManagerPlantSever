﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerServer.Database.Entity
{
    public class MeasuringDeviceEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey ("Zone")]

        public int? ZoneId { get; set; }
        [NotMapped]
        public ZoneEntity? Zone { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public DateTime? DateCreate { get; set; } = DateTime.Now;
        public DateTime? DateUpdate { get; set; }
        public bool? IsActive { get; set; } = true;
        public bool? IsProblem { get; set; } = false;
        [ForeignKey ("DeviceActionLog")]
        public int? DataDeviceResponsesId { get; set; }
        public List<DataDeviceResponseEntity>? DataDeviceResponses { get; set; }
        public DeviceActionLogEntity? DeviceActionLog { get; set; }
        public List<StatisticalDataResponseForHourEntity>? StatisticalDataResponsesForHours { get; set; }
        public List<StatisticalDataResponseForDayEntity>? StatisticalDataResponsesForDays { get; set; }
        public List<StatisticalDataResponseForWeekEntity>? StatisticalDataResponsesForWeek { get; set; }
        public List<StatisticalDataResponseForMonthEntity>? StatisticalDataResponsesForMonth { get; set; }
    }
}
