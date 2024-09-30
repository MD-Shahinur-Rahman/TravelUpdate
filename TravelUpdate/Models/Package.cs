using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelUpdate.Models
{
    public class Package
    {
        public int PackageID { get; set; }
        public string PackageTitle { get; set; } = "";
        public string PackageDescription { get; set; } = "";
        public bool IsAvailable { get; set; }

        public int CategoryID { get; set; }
        public virtual PackageCategory? Category { get; set; }

        public int? SubCategoryID { get; set; }
        public virtual PackageSubCategory? SubCategory { get; set; }

        // Navigation properties
        public ICollection<PackageGallery> PackageGallery { get; set; } = new List<PackageGallery>();
        public virtual ICollection<PackageDetails> PackageDetails { get; set; } = new List<PackageDetails>();
        public ICollection<PackageFacility> PackageFacilities { get; set; } = new List<PackageFacility>();
        public ICollection<Schedule> Schedule { get; set; } = new List<Schedule>();
        public ICollection<PackageFAQ> PackageFAQ { get; set; } = new List<PackageFAQ>();
        public ICollection<PackageUser> PackageUsers { get; set; } = new List<PackageUser>();
        public ICollection<DayWiseTourCost> DayWiseTourCosts { get; set; } = new List<DayWiseTourCost>();
        public ICollection<PackageIncludes> PackageIncludes { get; set; } = new List<PackageIncludes>();
        public ICollection<PackageExcludes> PackageExcludes { get; set; } = new List<PackageExcludes>();
        public ICollection<PackageAccommodation> PackageAccommodations { get; set; } = new List<PackageAccommodation>();
        public ICollection<PackageTransportation> PackageTransportations { get; set; } = new List<PackageTransportation>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<PackageLocation> PackageLocations { get; set; } = new List<PackageLocation>(); 
     


        
    }


}
