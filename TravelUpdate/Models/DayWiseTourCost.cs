using System.ComponentModel.DataAnnotations.Schema;

namespace TravelUpdate.Models
{
    public class DayWiseTourCost
    {
        public int DayWiseTourCostID { get; set; }
        public int PackageID { get; set; }
        public Package? Package { get; set; }
        public string DayNumber { get; set; } = "";
        public string CostCategory { get; set; } = "";
        [Column(TypeName = "decimal(18,2)")]
        public decimal FoodCost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TransPortCost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AccomodationCost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OtherCost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCost { get; set; }

    }
}
