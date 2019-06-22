using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryApi.Models;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaintPaulItemsController : ControllerBase
    {
        private readonly InventoryContext _context;

        public SaintPaulItemsController(InventoryContext context)
        {
            _context = context;
            if (_context.SaintPaulItems.Count() == 0)
            {

                // Populating store inventory
                _context.SaintPaulItems.Add(new SaintPaulItem { Quantity = 12, ItemName = "12-inch Macbook" });
                _context.SaintPaulItems.Add(new SaintPaulItem { Quantity = 10, ItemName = "Microsoft Surface Go Bundle" });
                _context.SaintPaulItems.Add(new SaintPaulItem { Quantity = 50, ItemName = "Sun Ray 1 Thin Clients" });
                _context.SaintPaulItems.Add(new SaintPaulItem { Quantity = 30, ItemName = "HP EliteDesk 800" });
                _context.SaveChanges();
            }
        }

        // GET: api/SaintPaulItems
        [HttpGet]
        public IEnumerable<SaintPaulItem> GetSaintPaulItems()
        {
            return _context.SaintPaulItems;
        }

        // GET: api/SaintPaulItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaintPaulItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var saintPaulItem = await _context.SaintPaulItems.FindAsync(id);

            if (saintPaulItem == null)
            {
                return NotFound();
            }

            return Ok(saintPaulItem);
        }

        // PUT: api/SaintPaulItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaintPaulItem([FromRoute] int id, [FromBody] SaintPaulItem saintPaulItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != saintPaulItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(saintPaulItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaintPaulItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SaintPaulItems
        [HttpPost]
        public async Task<IActionResult> PostSaintPaulItem([FromBody] SaintPaulItem saintPaulItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SaintPaulItems.Add(saintPaulItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaintPaulItem", new { id = saintPaulItem.Id }, saintPaulItem);
        }

        // DELETE: api/SaintPaulItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaintPaulItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var saintPaulItem = await _context.SaintPaulItems.FindAsync(id);
            if (saintPaulItem == null)
            {
                return NotFound();
            }

            _context.SaintPaulItems.Remove(saintPaulItem);
            await _context.SaveChangesAsync();

            return Ok(saintPaulItem);
        }

        private bool SaintPaulItemExists(int id)
        {
            return _context.SaintPaulItems.Any(e => e.Id == id);
        }
    }
}