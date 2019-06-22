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
    public class MinneapolisItemsController : ControllerBase
    {
        private readonly InventoryContext _context;

        public MinneapolisItemsController(InventoryContext context)
        {
            _context = context;
            if (_context.MinneapolisItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.MinneapolisItems.Add(new MinneapolisItem {  Quantity = 12, ItemName = "Macbook Pro 2018" });
                _context.MinneapolisItems.Add(new MinneapolisItem { Quantity = 10, ItemName = "Microsoft Surface Pro 6" });
                _context.MinneapolisItems.Add(new MinneapolisItem { Quantity = 10, ItemName = "MacPro 2013" });
                _context.MinneapolisItems.Add(new MinneapolisItem { Quantity = 30, ItemName = "Microsoft Surface Pen" });
                _context.SaveChanges();
            }
        }

        // GET: api/MinneapolisItems
        [HttpGet]
        public IEnumerable<MinneapolisItem> GetMinneapolisItem()
        {
            return _context.MinneapolisItems;
        }

        // GET: api/MinneapolisItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMinneapolisItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var minneapolisItem = await _context.MinneapolisItems.FindAsync(id);

            if (minneapolisItem == null)
            {
                return NotFound();
            }

            return Ok(minneapolisItem);
        }

        // PUT: api/MinneapolisItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMinneapolisItem([FromRoute] int id, [FromBody] MinneapolisItem minneapolisItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != minneapolisItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(minneapolisItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MinneapolisItemExists(id))
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

        // POST: api/MinneapolisItems
        [HttpPost]
        public async Task<IActionResult> PostMinneapolisItem([FromBody] MinneapolisItem minneapolisItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MinneapolisItems.Add(minneapolisItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMinneapolisItem", new { id = minneapolisItem.Id }, minneapolisItem);
        }

        // DELETE: api/MinneapolisItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMinneapolisItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var minneapolisItem = await _context.MinneapolisItems.FindAsync(id);
            if (minneapolisItem == null)
            {
                return NotFound();
            }

            _context.MinneapolisItems.Remove(minneapolisItem);
            await _context.SaveChangesAsync();

            return Ok(minneapolisItem);
        }

        private bool MinneapolisItemExists(int id)
        {
            return _context.MinneapolisItems.Any(e => e.Id == id);
        }
    }
}