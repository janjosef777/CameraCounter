using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CameraCounter.Data;
using CameraCounter.Models;

namespace CameraCounter.Controllers
{
    public class ProductionOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductionOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductionOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductionOrders.Include(p => p.Line);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductionOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionOrder = await _context.ProductionOrders
                .Include(p => p.Line)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productionOrder == null)
            {
                return NotFound();
            }

            return View(productionOrder);
        }

        // GET: ProductionOrders/Create
        public IActionResult Create()
        {
            ViewData["LineID"] = new SelectList(_context.Lines, "ID", "ID");
            return View();
        }

        // POST: ProductionOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CamerasMade,CamerasFailed,DateDone,LineID")] ProductionOrder productionOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LineID"] = new SelectList(_context.Lines, "ID", "ID", productionOrder.LineID);
            return View(productionOrder);
        }

        // GET: ProductionOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionOrder = await _context.ProductionOrders.FindAsync(id);
            if (productionOrder == null)
            {
                return NotFound();
            }
            ViewData["LineID"] = new SelectList(_context.Lines, "ID", "ID", productionOrder.LineID);
            return View(productionOrder);
        }

        // POST: ProductionOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CamerasMade,CamerasFailed,DateDone,LineID")] ProductionOrder productionOrder)
        {
            if (id != productionOrder.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productionOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionOrderExists(productionOrder.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LineID"] = new SelectList(_context.Lines, "ID", "ID", productionOrder.LineID);
            return View(productionOrder);
        }

        // GET: ProductionOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionOrder = await _context.ProductionOrders
                .Include(p => p.Line)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productionOrder == null)
            {
                return NotFound();
            }

            return View(productionOrder);
        }

        // POST: ProductionOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionOrder = await _context.ProductionOrders.FindAsync(id);
            _context.ProductionOrders.Remove(productionOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionOrderExists(int id)
        {
            return _context.ProductionOrders.Any(e => e.ID == id);
        }
    }
}
