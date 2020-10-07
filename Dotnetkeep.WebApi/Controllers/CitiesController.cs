using Dotnetkeep.WebApi.Context;
using Dotnetkeep.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnetkeep.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {

        WebApiDbContext _context;

        public CitiesController(WebApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("countries/{countryid}")]
        public async Task<ActionResult<IEnumerable<City>>> GetByCountryId(int countryId)
        {
            var list = await _context.Cities.Where(s => s.CountryId == countryId).ToListAsync();

            if (!list.Any())
            {
                return NotFound();
            }

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetById(int id)
        {
            var result = await _context.Cities.FirstOrDefaultAsync(s => s.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Post(City city)
        {
            try
            {
               

                _context.Cities.Add(city);


                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = city.Id }, city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(City city)
        {
            try
            {
                var existingCity = _context.Cities.FirstOrDefault(s => s.Id == city.Id);

                if (existingCity == null) throw new Exception("not existing city");

                existingCity.CountryId = city.CountryId;
                existingCity.Name = city.Name;

                _context.Update(existingCity);

                await _context.SaveChangesAsync();


                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var existingCity = _context.Cities.FirstOrDefault(s => s.Id == id);

                if (existingCity == null) throw new Exception("not existing city");

                _context.Cities.Remove(existingCity);

                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
