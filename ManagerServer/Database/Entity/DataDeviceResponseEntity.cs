using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerServer.Database.Entity
{
    public class DataDeviceResponseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Topic { get; set; }
        public string? Payload { get; set; }
        public DateTime? TimeRetrieve { get; set; }
        public string? Type { get; set; }
        [ForeignKey ("MeasuringDevice")]
        public string? DataDeviceId { get; set; }
        [NotMapped]
        public MeasuringDeviceEntity? MeasuringDevice { get; set; }
    }
}
