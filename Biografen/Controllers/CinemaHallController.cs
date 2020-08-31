using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biografen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biografen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaHallController : ControllerBase
    {
        //henter data fra DatabaseContext 
        private readonly DatabaseContext _context;

        public CinemaHallController(DatabaseContext context)
        {
            _context = context;
        }

        //GET: Api/cinemahall
        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemaHall>>> GetCinemaHalls()
        {
            return await _context.cinemaHalls.ToListAsync();
        }

        //Get: api/CinemaHalls/5
        [HttpGet("{id}")]

        [HttpGet("{id}")]
        public async Task<ActionResult<Administrator>> GetCinemaHalls(int id)
        {
            var admin = await _context.cinemaHalls.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // PUT: api/administrator/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrator(int id, CinemaHall cinema)
        {
            if (id != cinema.cinemahallId)
            {
                return BadRequest();
            }

            _context.Entry(c).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorExists(id))
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
    }
}
