namespace TravelUpdate.Models.InputModels
{
    public class HotelFacilityDto
    {
        public int HotelFacilityId { get; set; } // Optional for updates

        public int FacilityID { get; set; } // The ID of the facility (FK)
        
    }
}
