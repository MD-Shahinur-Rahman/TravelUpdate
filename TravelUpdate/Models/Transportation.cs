﻿using System.ComponentModel.DataAnnotations;

namespace TravelUpdate.Models
{
    public class Transportation /*: BaseClass*/
    {
        public int TransportationID { get; set; }
        public bool IsActive { get; set; }
        public int TransportProviderID { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        
        public TransportProvider TransportProvider { get; set; }
        public ICollection<PackageTransportation> PackageTransportations { get; set; }
    }

}
