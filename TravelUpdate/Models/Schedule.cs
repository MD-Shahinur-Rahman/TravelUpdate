using System.ComponentModel.DataAnnotations.Schema;

namespace TravelUpdate.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }= 1;
        public int TourVoucherID {  get; set; }
        public string ScheduleTitle { get; set; } = "JourneyStart/LunchBreak/MeetingTiming";
        public string? ScheduleDescription { get; set; }
        public int PackageID { get; set; } = 1;
        public Package? Package { get; set; }
        public int DayNumber { get; set; } = 1;
        public DateTime TentativeTime { get; set; }
        public DateTime? ActualTime { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal TentativeCost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal? ActualCost { get; set; }
        public decimal ScheduleCumulativeCost { get; set; } = 0;     
        public string Category { get; set; } = "";//type-Transportation, Food, Hotel, Others        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public virtual TourVoucher? TourVoucher { get; set; }
    }
}
