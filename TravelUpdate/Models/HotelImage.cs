namespace TravelUpdate.Models
{
    public class HotelImage
    {
        public int HotelImageID { get; set; }
        public string ImageUrl { get; set; } 
       
        public string Caption { get; set; }
        public bool IsThumbnail { get; set; } 
        public DateTime CreatedOn { get; set; }

        // Foreign Key
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }
    }

}