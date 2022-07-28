#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalManagementSystem.Web.Data;
using AutoMapper;
using GlobalManagementSystem.Web.Models;
using Microsoft.AspNetCore.Authorization;
using GlobalManagementSystem.Web.Constants;

namespace GlobalManagementSystem.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public ProductTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: ProductTypes
        public async Task<IActionResult> Index()
        {
            var productTypes = mapper.Map<List<ProductTypeVM>>(await _context.ProductTypes.Include(p => p.Make).ToListAsync());
            return View(productTypes);
        }

        // GET: ProductTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _context.ProductTypes.Include(p => p.Make).FirstOrDefaultAsync(m => m.Id == id);
            if (productType == null)
            {
                return NotFound();
            }

            var productTypeVM = mapper.Map<ProductTypeVM>(productType);
            ViewData["MakeId"] = new SelectList(_context.Makes, "Id", "Id", productType.MakeId);
            return View(productTypeVM);
        }

        // GET: ProductTypes/Create
        public IActionResult Create()
        {
            ViewData["MakeId"] = new SelectList(_context.Makes, "Id", "Name");
            return View();
        }

        // POST: ProductTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypeVM productTypeVM)
        {
            if (ModelState.IsValid)
            {
                var productType = mapper.Map<ProductType>(productTypeVM);
                _context.Add(productType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MakeId"] = new SelectList(_context.Makes, "Id", "Name", productTypeVM.MakeId);
            return View(productTypeVM);
        }

        // GET: ProductTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _context.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            var productTypeVM = mapper.Map<ProductTypeVM>(productType);
            ViewData["MakeId"] = new SelectList(_context.Makes, "Id", "Name", productType.MakeId);
            return View(productTypeVM);
        }

        // POST: ProductTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductTypeVM productTypeVM)
        {
            if (id != productTypeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var productType = mapper.Map<ProductType>(productTypeVM);
                    _context.Update(productType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTypeExists(productTypeVM.Id))
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
            ViewData["MakeId"] = new SelectList(_context.Makes, "Id", "Id", productTypeVM.MakeId);
            return View(productTypeVM);
        }

        // GET: ProductTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _context.ProductTypes
                .Include(p => p.Make)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var productType = await _context.ProductTypes.FindAsync(id);
                _context.ProductTypes.Remove(productType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private bool ProductTypeExists(int id)
        {
            return _context.ProductTypes.Any(e => e.Id == id);
        }
    }
}