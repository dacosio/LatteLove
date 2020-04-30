using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LatteLove.Core;
using LatteLove.Datos;

namespace LatteLove.Pages.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoffeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Coffees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coffee>>> GetCoffee()
        {
            return await _context.Coffee.ToListAsync();
        }

        // GET: api/Coffees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coffee>> GetCoffee(int id)
        {
            var coffee = await _context.Coffee.FindAsync(id);

            if (coffee == null)
            {
                return NotFound();
            }

            return coffee;
        }

        // PUT: api/Coffees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoffee(int id, Coffee coffee)
        {
            if (id != coffee.Id)
            {
                return BadRequest();
            }

            _context.Entry(coffee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeeExists(id))
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

        // POST: api/Coffees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Coffee>> PostCoffee(Coffee coffee)
        {
            _context.Coffee.Add(coffee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoffee", new { id = coffee.Id }, coffee);
        }

        // DELETE: api/Coffees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Coffee>> DeleteCoffee(int id)
        {
            var coffee = await _context.Coffee.FindAsync(id);
            if (coffee == null)
            {
                return NotFound();
            }

            _context.Coffee.Remove(coffee);
            await _context.SaveChangesAsync();

            return coffee;
        }

        private bool CoffeeExists(int id)
        {
            return _context.Coffee.Any(e => e.Id == id);
        }
    }
}
