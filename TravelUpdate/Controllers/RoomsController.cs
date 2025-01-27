﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TravelUpdate.Dal;
using TravelUpdate.Models;
using TravelUpdate.Models.InputModels;
using TravelUpdate.Models.OutputModels;

namespace TravelUpdate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly TravelDBContext _context;

        public RoomsController(TravelDBContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public IActionResult GetRooms()
        {
            var rooms = _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.RoomType)
                .Include(r => r.RoomSubType);
            return Ok(rooms.Select(r => new RoomDTO
            {
                RoomID = r.RoomID,
                AveragePrice = r.AveragePrice,
                MaxOccupancy = r.MaxOccupancy,
                IsAvailable = r.IsAvailable,
                HotelID = r.HotelID,

                RoomTypeID = r.RoomTypeID,

                RoomSubTypeID = r.RoomSubTypeID,

            }));
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var room = _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.RoomType)
                .Include(r => r.RoomSubType)
                .FirstOrDefault(r => r.RoomID == id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(new RoomDTO
            {
                RoomID = room.RoomID,
                AveragePrice = room.AveragePrice,
                MaxOccupancy = room.MaxOccupancy,
                IsAvailable = room.IsAvailable,
                HotelID = room.HotelID,

                RoomTypeID = room.RoomTypeID,

                RoomSubTypeID = room.RoomSubTypeID,

            });
        }

        // POST: api/Rooms
        [HttpPost]
        public IActionResult CreateRoom(RoomDTOs roomDTO, [FromQuery] string? customUrl = null)
        {
            var room = _context.Hotels.Find(roomDTO.HotelID);
            var roomType = _context.RoomTypes.Find(roomDTO.RoomTypeID);
            var roomSubType = _context.RoomSubTypes.Find(roomDTO.RoomSubTypeID);

            if (room == null || roomType == null || roomSubType == null)
            {
                return NotFound();
            }

            var rooms = new Room
            {
                AveragePrice = roomDTO.AveragePrice,
                MaxOccupancy = roomDTO.MaxOccupancy,
                IsAvailable = roomDTO.IsAvailable,
                HotelID = roomDTO.HotelID,
                
                RoomTypeID = roomDTO.RoomTypeID,
               
                RoomSubTypeID = roomDTO.RoomSubTypeID,
               
            };

            _context.Rooms.Add(rooms);
            _context.SaveChanges();
            var url = customUrl ?? "getRoom";
            return Ok(new { RoomID = rooms.RoomID, Url = url });
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public IActionResult UpdateRoom(int id, RoomDTOs roomDTO, [FromQuery] string? customUrl = null)
        {
            var room = _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.RoomType)
                .Include(r => r.RoomSubType)
                .FirstOrDefault(r => r.RoomID == id);
            if (room == null)
            {
                return NotFound();
            }

            var hotel = _context.Hotels.Find(roomDTO.HotelID);
            var roomType = _context.RoomTypes.Find(roomDTO.RoomTypeID);
            var roomSubType = _context.RoomSubTypes.Find(roomDTO.RoomSubTypeID);

            if (hotel == null || roomType == null || roomSubType == null)
            {
                return NotFound();
            }

            room.AveragePrice = roomDTO.AveragePrice;
            room.MaxOccupancy = roomDTO.MaxOccupancy;
            room.IsAvailable = roomDTO.IsAvailable;
            room.HotelID = roomDTO.HotelID;
          
            room.RoomTypeID = roomDTO.RoomTypeID;
            
            room.RoomSubTypeID = roomDTO.RoomSubTypeID;
     

            _context.Rooms.Update(room);
            _context.SaveChanges();
            var url = customUrl ?? "getRoom";
            return Ok(new { RoomID = room.RoomID, Url = url });
        }
        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return Ok("Deleted Sucessfull");
        }
    }
}
