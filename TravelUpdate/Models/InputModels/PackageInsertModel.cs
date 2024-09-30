using System.ComponentModel.DataAnnotations;

namespace TravelUpdate.Models.InputModels
{
    public class PackageInsertModel
    {
        [Required(ErrorMessage = "Package title is required")]
        [StringLength(100, ErrorMessage = "Package title can't be longer than 100 characters")]
        public string PackageTitle { get; set; } = "";

        [Required(ErrorMessage = "Package description is required")]
        
        public string PackageDescription { get; set; } = "";

        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        public int CategoryID { get; set; }

        public int? SubCategoryID { get; set; }
    }

}
