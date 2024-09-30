using Microsoft.AspNetCore.Mvc;

using TravelUpdate.Models.InputModels;
using TravelUpdate.Models;
using TravelUpdate.Dal;
using Microsoft.EntityFrameworkCore;

namespace TravelUpdate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomTypesController : ControllerBase
    {
        private readonly TravelDBContext _context;

        public RoomTypesController(TravelDBContext context)
        {
            _context = context;
        }

        // GET: api/RoomTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomTypeDTO>>> GetRoomTypes()
        {
            var roomTypes = await _context.RoomTypes.ToListAsync();
            return roomTypes.Select(rt => new RoomTypeDTO { RoomTypeID = rt.RoomTypeID, TypeName = rt.TypeName }).ToList();
        }

        // GET: api/RoomTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomTypeDTO>> GetRoomType(int id)
        {
            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }
            return new RoomTypeDTO { RoomTypeID = roomType.RoomTypeID, TypeName = roomType.TypeName };
        }

        // POST: api/RoomTypes
        [HttpPost]
        public async Task<ActionResult<RoomTypeDTO>> CreateRoomType([FromForm] RoomTypeDTO roomTypeDTO, [FromQuery] string? customUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RoomType roomType = new RoomType
            {
                TypeName = roomTypeDTO.TypeName
            };

            _context.RoomTypes.Add(roomType);
            await _context.SaveChangesAsync();

            var url = customUrl ?? "getroomtype";
            return CreatedAtAction(nameof(GetRoomType), new { id = roomType.RoomTypeID }, new { RoomTypeID = roomType.RoomTypeID, Url = url });
        }

        // PUT: api/RoomTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoomType(int id, [FromForm] RoomTypeDTO roomTypeDTO, [FromQuery] string? customUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            roomType.TypeName = roomTypeDTO.TypeName;

            _context.RoomTypes.Update(roomType);
            await _context.SaveChangesAsync();

            var url = customUrl ?? "getroomtype";
            return Ok(new { RoomTypeID = roomType.RoomTypeID, Url = url });
        }

        // DELETE: api/RoomTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            _context.RoomTypes.Remove(roomType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}