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
        public async Task<IActionResult> PostTransactionRoot(IFormFile file)
        {
            var cnabData = new List<string>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string? line = null;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    cnabData.Add(line);
                }
            }

            var transactions = new List<TransactionRoot>();
            foreach (var cnab in cnabData)
            {
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

        private bool TransactionRootExists(Guid id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
