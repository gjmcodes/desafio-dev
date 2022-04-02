#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ByC.Domain.Transactions.Entities;
using ByC.REST.Data;

namespace ByC.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CnabController : ControllerBase
    {
        private readonly ByCDbContext _context;

        public CnabController(ByCDbContext context)
        {
            _context = context;
        }

        // GET: api/Cnab
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CnabRoot>>> GetCnabs()
        {
            return await _context.Cnabs.ToListAsync();
        }

        // GET: api/Cnab/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CnabRoot>> GetCnabRoot(string id)
        {
            var cnabRoot = await _context.Cnabs.FindAsync(id);

            if (cnabRoot == null)
            {
                return NotFound();
            }

            return cnabRoot;
        }
    }
}
