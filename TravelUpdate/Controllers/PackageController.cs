using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelUpdate.Models.InputModels;
using TravelUpdate.Models;
using TravelUpdate.Dal;

namespace TravelUpdate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly TravelDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PackageController(TravelDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }


        [HttpPost("add-package")]
        public async Task<IActionResult> CreatePackage([FromBody] PackageInsertModel model, [FromQuery] string? customUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var package = new Package
            {
                PackageTitle = model.PackageTitle,
                PackageDescription = model.PackageDescription,
                IsAvailable = model.IsAvailable,
                CategoryID = model.CategoryID,
                SubCategoryID = model.SubCategoryID
            };

            _context.Packages.Add(package);
            await _context.SaveChangesAsync();

            var url = customUrl ?? "getpackage";

            return CreatedAtAction(nameof(CreatePackage), new { packageId = package.PackageID }, new
            {
                success = true,
                message = "Package created successfully.",
                packageId = package.PackageID,
                url
            });
        }

        [HttpPost("add-package-details/{packageId}")]
        public async Task<IActionResult> AddPackageDetails(int packageId, [FromBody] PackageDetailsInsertModel model)
        {
            // Check if the package exists
            var package = await _context.Packages.FindAsync(packageId);
            if (package == null)
            {
                return NotFound(new { success = false, message = "Package not found." });
            }

            // Create the PackageDetails object
            var packageDetails = new PackageDetails
            {
                PackageID = packageId,
                PackageDuration = model.PackageDuration,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                PickupPoint = model.PickupPoint,
                MaximumPerson = model.MaximumPerson,
                MinimumPerson = model.MinimumPerson
            };

            // Add the PackageDetails to the context and save it
            _context.PackageDetails.Add(packageDetails);
            await _context.SaveChangesAsync();

            // Return success message with the PackageDetailsID
            return Ok(new
            {
                success = true,
                message = "Package details added successfully.",
                packageDetailsId = packageDetails.PackageDetailsID
            });
        }





    }
}
