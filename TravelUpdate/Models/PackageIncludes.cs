using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelUpdate.Models
{
    public class PackageIncludes
    {
        [Key]
        public int IncludeID { get; set; }

        [Required]
        public int PackageID { get; set; }

        [Required]
        [StringLength(1000)]  // Adjust the length based on your needs
        public string IncludeDescription { get; set; } // long text to insert details

        // Navigation properties
        [ForeignKey("PackageID")]
        public Package Package { get; set; }
    }

}
