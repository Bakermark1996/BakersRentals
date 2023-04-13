using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BakersRentals.Data;
using BakersRentals.Models;

namespace BakersRentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RentalsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RentalsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRental()
        {
          if (_context.Rental == null)
          {
              return NotFound();
          }
            return await _context.Rental.ToListAsync();
        }

        // GET: api/RentalsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRental(int id)
        {
          if (_context.Rental == null)
          {
              return NotFound();
          }
            var rental = await _context.Rental.FindAsync(id);

            if (rental == null)
            {
                return NotFound();
            }

            return rental;
        }

        // PUT: api/RentalsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRental(int id, Rental rental)
        {
            if (id != rental.Id)
            {
                return BadRequest();
            }

            _context.Entry(rental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(id))
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

        // POST: api/RentalsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rental>> PostRental(Rental rental)
        {
          if (_context.Rental == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Rental'  is null.");
          }
            _context.Rental.Add(rental);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRental", new { id = rental.Id }, rental);
        }

        // DELETE: api/RentalsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            if (_context.Rental == null)
            {
                return NotFound();
            }
            var rental = await _context.Rental.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            _context.Rental.Remove(rental);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentalExists(int id)
        {
            return (_context.Rental?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
