using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelUpdate.Models
{
    public class PackageTransportation
    {
        public int PackageTransportationID { get; set; }
        public int PackageID { get; set; }
        public int TransportationTypeID { get; set; } // bus , truck, train , nouka,
        public int TransportationCatagoryID { get; set; }  //ac , non ac
        public int TransportationID { get; set; }
        public int SeatBooked { get; set; } = 10;

        [StringLength(500)]
        public string PackageTransportationDescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PerHeadTransportCost { get; set; }
        public Package Package { get; set; } = new Package(); // Ensures it's not null
        public Transportation Transportation { get; set; } = new Transportation(); // Ensures it's not null
        public TransportationType TransportationType { get; set; }
        public TransportationCatagory TransportationCatagorys { get; set; }
        public ICollection<Seats> Seats { get; set; }
    }
}