using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("/ConfRoom")]
    [ApiController]
    public class ConfRoomController : ControllerBase
    {
        private readonly ConfRoomContext _context;

        public ConfRoomController(ConfRoomContext context)
        {
            _context = context;

            if (_context.ConfRoomItems.Count() == 0)
            {
                // There always be one item in DB
                _context.ConfRoomItems.Add(
                   new ConfRoomItem {
                       RoomNr = 100,
                       RenterName = "You",
                       IsRented = true
                });
                _context.SaveChanges();
            }
        }

        // GET All 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfRoomItem>>> GetAll()
        {
            return await _context.ConfRoomItems.ToListAsync();
        }

        // GET with ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfRoomItem>> Get(long id)
        {
            var TempItem = await _context.ConfRoomItems.FindAsync(id);

            if (TempItem == null)
            {
                return NotFound(new { error = "No element with such ID found in database." });
            }

            return TempItem;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<ConfRoomItem>> Post(ConfRoomItem TempItem)
        {
            bool check = _context.ConfRoomItems.Any(x => x.RoomNr == TempItem.RoomNr);
            if (check)
            {
                return BadRequest(new { error = "This room is occupied already." });
            }

            _context.ConfRoomItems.Add(TempItem);
            await _context.SaveChangesAsync();

            return Ok(new { call = "Element successfully added." });
        }

        // PUT 
        [HttpPut("{id}")]
        public async Task<ActionResult<ConfRoomItem>> Put(long id, ConfRoomItem TempItem)
        {
            if (id != TempItem.Id)
            {
                return BadRequest(new { error = "Wrong ID in url or file." });
            }

            var FindID = await _context.ConfRoomItems.FindAsync(TempItem.Id);

            if (FindID == null)
            {
                return NotFound(new { error = "No element with such ID found in database." });
            }
 
            _context.Entry(TempItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { call = "Element successfully updated." });
        }

        // PATCH 
        [HttpPatch("{id}")]
        public async Task<ActionResult<ConfRoomItem>> Patch(long id, ConfRoomItem TempItem)
        {
            // Patch implementation

            return NotFound(new { error = "Implement method." });
        }

        // DELETE with ID
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConfRoomItem>> Delete(long id)
        {
            var TempItem = await _context.ConfRoomItems.FindAsync(id);
            if (TempItem == null)
            {
                return NotFound(new { error = "No element with such ID in database." });
            }

            _context.ConfRoomItems.Remove(TempItem);
            await _context.SaveChangesAsync();

            return Ok(new { call = "Element successfully removed form database." });
        }
    }
}