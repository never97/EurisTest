using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EurisTest.Data;
using EurisTest.Models;
using EurisTest.Models.ViewModels;

namespace EurisTest.Controllers
{
    public class CatalogsController : Controller
    {
        private readonly EurisTestContext _context;

        public CatalogsController(EurisTestContext context)
        {
            _context = context;
        }

        // GET: Catalogs
        public async Task<IActionResult> Index()
        {
              return _context.Catalog != null ? 
                          View(await _context.Catalog.ToListAsync()) :
                          Problem("Entity set 'EurisTestContext.Catalog'  is null.");
        }

        // GET: Catalogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Catalog == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalog
                .FirstOrDefaultAsync(m => m.CatalogId == id);
            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }

        // GET: Catalogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatalogId,Code,Description")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalog);
        }

        // GET: Catalogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Catalog == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalog.FindAsync(id);
            /*var catalog = await _context.Catalog
            .Include(i => i.CatalogProducts).ThenInclude(i => i.Product)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.CatalogId == id);*/
            if (catalog == null)
            {
                return NotFound();
            }
            //PopulateAssignedCatalogData(catalog);
            return View(catalog);
        }
        /*private void PopulateAssignedCatalogData(Catalog catalog)
        {
            var allCourses = _context.Product;
            var instructorCourses = new HashSet<int>(catalog.CatalogProducts.Select(c => c.ProductId));
            var viewModel = new List<AssignedProductData>();
            foreach (var product in allCourses)
            {
                viewModel.Add(new AssignedProductData
                {
                    ProductId = product.ProductId,
                    Code = product.Code,
                    Assigned = instructorCourses.Contains(product.ProductId)
                });
            }
            ViewData["Courses"] = viewModel;
        }*/


        // POST: Catalogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatalogId,Code,Description")] Catalog catalog)
        {
            if (id != catalog.CatalogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogExists(catalog.CatalogId))
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
            return View(catalog);
        }

        // GET: Catalogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Catalog == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalog
                .FirstOrDefaultAsync(m => m.CatalogId == id);
            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }

        // POST: Catalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Catalog == null)
            {
                return Problem("Entity set 'EurisTestContext.Catalog'  is null.");
            }
            var catalog = await _context.Catalog.FindAsync(id);
            if (catalog != null)
            {
                _context.Catalog.Remove(catalog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogExists(int id)
        {
          return (_context.Catalog?.Any(e => e.CatalogId == id)).GetValueOrDefault();
        }
    }
}
