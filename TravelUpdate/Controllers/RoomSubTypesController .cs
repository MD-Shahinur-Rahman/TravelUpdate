using Microsoft.AspNetCore.Mvc;

using TravelUpdate.Models.InputModels;
using TravelUpdate.Models;
using TravelUpdate.Dal;
using Microsoft.EntityFrameworkCore;

namespace TravelUpdate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomSubTypesController : ControllerBase
    {
        private readonly TravelDBContext _context;

        public RoomSubTypesController(TravelDBContext context)
        {
            _context = context;
        }

        // GET: api/RoomSubTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomSubTypeDTO>>> GetRoomSubTypes()
        {
            var roomSubTypes = await _context.RoomSubTypes.ToListAsync();
            return roomSubTypes.Select(rst => new RoomSubTypeDTO { RoomSubTypeID = rst.RoomSubTypeID, SubTypeName = rst.SubTypeName }).ToList();
        }

        // GET: api/RoomSubTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomSubTypeDTO>> GetRoomSubType(int id)
        {
            var roomSubType = await _context.RoomSubTypes.FindAsync(id);
            if (roomSubType == null)
            {
                return NotFound();
            }
            return new RoomSubTypeDTO { RoomSubTypeID = roomSubType.RoomSubTypeID, SubTypeName = roomSubType.SubTypeName };
        }

        // POST: api/RoomSubTypes
        [HttpPost]
        public async Task<ActionResult<RoomSubTypeDTO>> CreateRoomSubType([FromForm] RoomSubTypeDTO roomSubTypeDTO, [FromQuery] string? customUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RoomSubType roomSubType = new RoomSubType
            {
                SubTypeName = roomSubTypeDTO.SubTypeName
            };

            _context.RoomSubTypes.Add(roomSubType);
            await _context.SaveChangesAsync();

            var url = customUrl ?? "getroomsubtype";
            return CreatedAtAction(nameof(GetRoomSubType), new { id = roomSubType.RoomSubTypeID }, new { RoomSubTypeID = roomSubType.RoomSubTypeID, Url = url });
        }

        // PUT: api/RoomSubTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoomSubType(int id, [FromForm] RoomSubTypeDTO roomSubTypeDTO, [FromQuery] string? customUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomSubType = await _context.RoomSubTypes.FindAsync(id);
            if (roomSubType == null)
            {
                return NotFound();
            }

            roomSubType.SubTypeName = roomSubTypeDTO.SubTypeName;

            _context.Entry(roomSubType).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var url = customUrl ?? "getroomsubtype";
            return Ok(new { RoomSubTypeID = roomSubType.RoomSubTypeID, Url = url });
        }

        // DELETE: api/RoomSubTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomSubType(int id)
        {
            var roomSubType = await _context.RoomSubTypes.FindAsync(id);
            if (roomSubType == null)
            {
                return NotFound();
            }

            _context.RoomSubTypes.Remove(roomSubType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}