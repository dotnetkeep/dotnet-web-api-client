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
    public class CountriesController : ControllerBase
    {
        WebApiDbContext _context;

        public CountriesController(WebApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            var list = await _context.Countries.ToListAsync();

            if (!list.Any())
            {
                return NotFound();
            }

            return list;
        }

        [HttpGet("{isocode}")]
        public async Task<ActionResult<Country>> GetByISO(string isoCode)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(s => s.ISOCode == isoCode);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }
    }
 }
