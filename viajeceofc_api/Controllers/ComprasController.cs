using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using viajeceofc_api.Context;
using viajeceofc_api.Models;

namespace viajeceofc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly DataContext _context;

        public ComprasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Compras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compras>>> GetCompras()
        {
          if (_context.Compras == null)
          {
              return NotFound();
          }
            return await _context.Compras.ToListAsync();
        }

        // GET: api/Compras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compras>> GetCompras(int id)
        {
          if (_context.Compras == null)
          {
              return NotFound();
          }
            var compras = await _context.Compras.FindAsync(id);

            if (compras == null)
            {
                return NotFound();
            }

            return compras;
        }

        // PUT: api/Compras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompras(int id, Compras compras)
        {
            if (id != compras.Id)
            {
                return BadRequest();
            }

            _context.Entry(compras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprasExists(id))
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

        // POST: api/Compras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Compras>> PostCompras(Compras compras)
        {
          if (_context.Compras == null)
          {
              return Problem("Entity set 'DataContext.Compras'  is null.");
          }
            _context.Compras.Add(compras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompras", new { id = compras.Id }, compras);
        }

        // DELETE: api/Compras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompras(int id)
        {
            if (_context.Compras == null)
            {
                return NotFound();
            }
            var compras = await _context.Compras.FindAsync(id);
            if (compras == null)
            {
                return NotFound();
            }

            _context.Compras.Remove(compras);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComprasExists(int id)
        {
            return (_context.Compras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
