using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fids_api.Models;

namespace fids_api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightAPIController : ControllerBase
    {
        private readonly fidsContext _context;

        public FlightAPIController(fidsContext context)
        {
            _context = context;
        }
        
        // Search api for origin or destination
        [HttpGet("search/{search}")]
        public async Task<ActionResult<IEnumerable<FlightDetail>>> GetFlight(string search)
        {
            var flight = await _context.FlightDetails.Where(f => f.Origin.Contains(search) || f.Destination.Contains(search)).ToListAsync();

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }
        

        // GET: api/FlightAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDetail>>> GetFlightDetails()
        {
          if (_context.FlightDetails == null)
          {
              return NotFound();
          }
            return await _context.FlightDetails.ToListAsync();
        }

        // GET: api/FlightAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDetail>> GetFlightDetail(int id)
        {
          if (_context.FlightDetails == null)
          {
              return NotFound();
          }
            var flightDetail = await _context.FlightDetails.FindAsync(id);

            if (flightDetail == null)
            {
                return NotFound();
            }

            return flightDetail;
        }

        // PUT: api/FlightAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightDetail(int id, FlightDetail flightDetail)
        {
            if (id != flightDetail.FlightId)
            {
                return BadRequest();
            }

            _context.Entry(flightDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightDetailExists(id))
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

        // POST: api/FlightAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightDetail>> PostFlightDetail(FlightDetail flightDetail)
        {
          if (_context.FlightDetails == null)
          {
              return Problem("Entity set 'fidsContext.FlightDetails'  is null.");
          }
            _context.FlightDetails.Add(flightDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightDetail", new { id = flightDetail.FlightId }, flightDetail);
        }

        // DELETE: api/FlightAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightDetail(int id)
        {
            if (_context.FlightDetails == null)
            {
                return NotFound();
            }
            var flightDetail = await _context.FlightDetails.FindAsync(id);
            if (flightDetail == null)
            {
                return NotFound();
            }

            _context.FlightDetails.Remove(flightDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightDetailExists(int id)
        {
            return (_context.FlightDetails?.Any(e => e.FlightId == id)).GetValueOrDefault();
        }
    }
}
