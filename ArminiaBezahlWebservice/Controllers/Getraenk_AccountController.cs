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
    public class Getraenk_AccountController : ControllerBase
    {
        private readonly ArminiaBezahlWebserviceContext _context;

        public Getraenk_AccountController(ArminiaBezahlWebserviceContext context)
        {
            _context = context;
        }

        // GET: api/Getraenk_Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AktuelleRechnung>> GetGetraenk_Account(int id)
        {
            var summe = await _context.Getraenk_Account.Where(
                    ga => ga.AccountId == id && ga.Bezahlt == false).
                Join(
                    _context.Getraenk,
                    ga => ga.GetraenkId,
                    g => g.Id,
                    (
                        ga,
                        g) => new
                    {
                        Preise = g.Preis
                    }).
                SumAsync(p => p.Preise);


            return new AktuelleRechnung() { Rechnungsbetrag = summe };
        }

        // GET: api/Getraenk_Account/rechnung/5
        [HttpGet("rechnung/{id}")]
        public async Task<ActionResult<List<EinzelaustellungGetraenke>>> GetRechnungAuflistung(
            int id)
        {
            var einzelausstellungen = await _context.Getraenk_Account.
                Where(ga => ga.AccountId == id && ga.Bezahlt == false).
                GroupBy(g => g.GetraenkId).
                Select(
                    g => new
                    {
                        key = g.Key,
                        count = g.Count()
                    }).
                Join(
                    _context.Getraenk,
                    ga => ga.key,
                    g => g.Id,
                    (
                        ga,
                        g) => new EinzelaustellungGetraenke()

                    {
                        Titel = g.Titel,
                        Preis = g.Preis * ga.count,
                        Anzahl = ga.count
                    }).
                ToListAsync();

            return einzelausstellungen;
        }

        // PUT: api/Getraenk_Account/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGetraenk_Account(int id, Getraenk_Account getraenk_Account)
        {
            if (id != getraenk_Account.Id)
            {
                return BadRequest();
            }

            _context.Entry(getraenk_Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Getraenk_AccountExists(id))
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

        // POST: api/Getraenk_Account
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task PostGetraenk_Account(List<Getraenk_Account> getraenkAccount)
        {
            await _context.Getraenk_Account.AddRangeAsync(getraenkAccount);
            await _context.SaveChangesAsync();
        }

        // DELETE: api/Getraenk_Account/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Getraenk_Account>> DeleteGetraenk_Account(int id)
        {
            var getraenkAccount = await _context.Getraenk_Account.FindAsync(id);
            if (getraenkAccount == null)
            {
                return NotFound();
            }

            _context.Getraenk_Account.Remove(getraenkAccount);
            await _context.SaveChangesAsync();

            return getraenkAccount;
        }

        private bool Getraenk_AccountExists(int id)
        {
            return _context.Getraenk_Account.Any(e => e.Id == id);
        }
    }
}
