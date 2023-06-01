using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TenderManagementSytem.Models;

namespace TenderManagementSytem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderMastersController : ControllerBase
    {
        private readonly TenderManagementContext _context;

        public TenderMastersController(TenderManagementContext context)
        {
            _context = context;
        }

        // GET: api/TenderMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TenderMaster>>> GetTenderMaster()
        {
            return await _context.TenderMaster.ToListAsync();
        }

        // GET: api/TenderMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TenderMaster>> GetTenderMaster(int id)
        {
            var tenderMaster = await _context.TenderMaster.FindAsync(id);

            if (tenderMaster == null)
            {
                return NotFound();
            }

            return tenderMaster;
        }

        // PUT: api/TenderMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTenderMaster(int id, TenderMaster tenderMaster)
        {
            if (id != tenderMaster.TenderId)
            {
                return BadRequest();
            }

            _context.Entry(tenderMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenderMasterExists(id))
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

        // POST: api/TenderMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TenderMaster>> PostTenderMaster(TenderMaster tenderMaster)
        {
            _context.TenderMaster.Add(tenderMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTenderMaster", new { id = tenderMaster.TenderId }, tenderMaster);
        }

        // DELETE: api/TenderMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TenderMaster>> DeleteTenderMaster(int id)
        {
            var tenderMaster = await _context.TenderMaster.FindAsync(id);
            if (tenderMaster == null)
            {
                return NotFound();
            }

            _context.TenderMaster.Remove(tenderMaster);
            await _context.SaveChangesAsync();

            return tenderMaster;
        }

        private bool TenderMasterExists(int id)
        {
            return _context.TenderMaster.Any(e => e.TenderId == id);
        }
    }
}
