using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelUpdate.Models
{
    public class PackageExcludes
    {
        [Key]
        public int ExcludeID { get; set; }

        [Required]
        public int PackageID { get; set; }

        [Required]
        [StringLength(1000)]  // Adjust the length based on your needs
        public string ExcludeDescription { get; set; } // long text to insert details

        // Navigation properties
        [ForeignKey("PackageID")]
        public Package Package { get; set; }
    }
}
