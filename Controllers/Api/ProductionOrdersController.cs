using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CameraCounter.Data;
using CameraCounter.Models;

namespace CameraCounter.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionOrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductionOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductionOrders
        [HttpGet]
        public IEnumerable<ProductionOrder> GetProductionOrders()
        {
            return _context.ProductionOrders;
        }

        // GET: api/ProductionOrders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductionOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productionOrder = await _context.ProductionOrders.FindAsync(id);

            if (productionOrder == null)
            {
                return NotFound();
            }

            return Ok(productionOrder);
        }

        // PUT: api/ProductionOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductionOrder([FromRoute] int id, [FromBody] ProductionOrder productionOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productionOrder.ID)
            {
                return BadRequest();
            }

            _context.Entry(productionOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionOrderExists(id))
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

        // POST: api/ProductionOrders
        [HttpPost]
        public async Task<IActionResult> PostProductionOrder([FromBody] ProductionOrder productionOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductionOrders.Add(productionOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductionOrder", new { id = productionOrder.ID }, productionOrder);
        }

        // DELETE: api/ProductionOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productionOrder = await _context.ProductionOrders.FindAsync(id);
            if (productionOrder == null)
            {
                return NotFound();
            }

            _context.ProductionOrders.Remove(productionOrder);
            await _context.SaveChangesAsync();

            return Ok(productionOrder);
        }

        private bool ProductionOrderExists(int id)
        {
            return _context.ProductionOrders.Any(e => e.ID == id);
        }
    }
}