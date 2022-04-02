#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ByC.Domain.Transactions.Entities;
using ByC.REST.Data;

namespace ByC.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ByCDbContext _context;

        public TransactionController(ByCDbContext context)
        {
            _context = context;
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionRoot>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionRoot>> GetTransactionRoot(Guid id)
        {
            var transactionRoot = await _context.Transactions.FindAsync(id);

            if (transactionRoot == null)
            {
                return NotFound();
            }

            return transactionRoot;
        }


        // POST: api/Transaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTransactionRoot()
        {
            const string fileNotFound = "File not found in request";

            if (!Request.HasFormContentType)
                return BadRequest(fileNotFound);

            var requestForm = await Request.ReadFormAsync();
            var file = requestForm.FirstOrDefault(x => x.Key == "file");

            if (file.Key == null)
                return BadRequest(fileNotFound);

            var cnabFile = file.Value.Last();
            var cnabData = cnabFile.Split("\n");

            var transactions = new List<TransactionRoot>();
            foreach (var cnab in cnabData)
            {
                if (string.IsNullOrEmpty(cnab))
                    continue;

                var transaction = new TransactionRoot(cnab);
                transactions.Add(transaction);
                _context.Transactions.Add(transaction);
            }

            await _context.SaveChangesAsync();

            return Ok();

        }

        // DELETE: api/Transaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionRoot(Guid id)
        {
            var transactionRoot = await _context.Transactions.FindAsync(id);
            if (transactionRoot == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transactionRoot);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
