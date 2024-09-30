using System.ComponentModel.DataAnnotations.Schema;

namespace TravelUpdate.Models
{
    public class PackageFoodItem 
    {
        public int PackageFoodItemID { get; set; }
        public int MealTypeID { get; set; } = 1;//Breakfast
        public int FoodItemID {  get; set; }
        public int PackageID { get; set; }//Total Consuming Members will be collected by PackageID
        public int PackageDayNumber { get; set; } = 1;
        [Column(TypeName = "decimal(18,2)")]
        public decimal FoodQuantity {  get; set; }
        public double FoodUnitPrice { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ItemTotalCost { get; set; } = 800;
        //public string? RestaurantName {  get; set; }//repeated name with every Item
        public DateTime ScheduleTime { get; set; }
        public Package? Package { get; set; }        
        public MealType? MealType { get; set; }
        public virtual FoodItem? FoodItem { get; set; }
        
    }
}

