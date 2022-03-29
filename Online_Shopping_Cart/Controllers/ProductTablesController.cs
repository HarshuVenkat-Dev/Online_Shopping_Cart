using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Shopping_Cart.Models;

namespace Online_Shopping_Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTablesController : ControllerBase
    {
        private readonly Shopping_cartContext _context;

        public ProductTablesController(Shopping_cartContext context)
        {
            _context = context;
        }

        // GET: api/ProductTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTable>>> GetProductTables()
        {
            return await _context.ProductTables.ToListAsync();
        }

        // GET: api/ProductTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTable>> GetProductTable(int id)
        {
            var productTable = await _context.ProductTables.FindAsync(id);

            if (productTable == null)
            {
                return NotFound();
            }

            return productTable;
        }

        // PUT: api/ProductTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductTable(int id, ProductTable productTable)
        {
            if (id != productTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(productTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTableExists(id))
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

        // POST: api/ProductTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductTable>> PostProductTable(ProductTable productTable)
        {
            _context.ProductTables.Add(productTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductTable", new { id = productTable.Id }, productTable);
        }

        // DELETE: api/ProductTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductTable(int id)
        {
            var productTable = await _context.ProductTables.FindAsync(id);
            if (productTable == null)
            {
                return NotFound();
            }

            _context.ProductTables.Remove(productTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductTableExists(int id)
        {
            return _context.ProductTables.Any(e => e.Id == id);
        }
    }
}