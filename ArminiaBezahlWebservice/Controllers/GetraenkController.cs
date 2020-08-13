using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArminiaBezahlWebservice.Data;
using ArminiaBezahlWebservice.Models;

namespace ArminiaBezahlWebservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetraenkController : ControllerBase
    {
        private readonly ArminiaBezahlWebserviceContext _context;

        public GetraenkController(ArminiaBezahlWebserviceContext context)
        {
            _context = context;
        }

        // GET: api/Getraenk
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Getraenk>>> GetGetraenk()
        {
            return await _context.Getraenk.ToListAsync();
        }

        // GET: api/Getraenk/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Getraenk>> GetGetraenk(int id)
        {
            var getraenk = await _context.Getraenk.FindAsync(id);

            if (getraenk == null)
            {
                return NotFound();
            }

            return getraenk;
        }

        // PUT: api/Getraenk/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGetraenk(int id, Getraenk getraenk)
        {
            if (id != getraenk.Id)
            {
                return BadRequest();
            }

            _context.Entry(getraenk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetraenkExists(id))
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

        // POST: api/Getraenk
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Getraenk>> PostGetraenk(Getraenk getraenk)
        {
            _context.Getraenk.Add(getraenk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGetraenk", new { id = getraenk.Id }, getraenk);
        }

        // DELETE: api/Getraenk/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Getraenk>> DeleteGetraenk(int id)
        {
            var getraenk = await _context.Getraenk.FindAsync(id);
            if (getraenk == null)
            {
                return NotFound();
            }

            _context.Getraenk.Remove(getraenk);
            await _context.SaveChangesAsync();

            return getraenk;
        }

        private bool GetraenkExists(int id)
        {
            return _context.Getraenk.Any(e => e.Id == id);
        }
    }
}
