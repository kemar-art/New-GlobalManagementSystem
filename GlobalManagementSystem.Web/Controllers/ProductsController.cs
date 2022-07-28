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
using GlobalManagementSystem.Web.Contracts;

namespace GlobalManagementSystem.Web.Controllers
{
    [Authorize(Roles = "Administrator, User")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductsController(ApplicationDbContext context, IMapper mapper, IProductRepository productRepository
            )
        {
            _context = context;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = mapper.Map<List<ProductVM>>(await _context.Products.Include(p => p.Condition).Include(p => p.Model.ProductType.Make).ToListAsync());
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productVM = await productRepository.GetProductview(id.Value);
            return View(productVM);
        }
        [Authorize(Roles = Roles.Administrator)]
        // GET: Products/Create
        public IActionResult Create()
        {
            var models = _context.Models.Include(q => q.ProductType.Make)
                .Select(q => new { Id = q.Id, Name = $"{q.ProductType.Make.Name} | {q.ProductType.Name} | {q.Name}" })
                .ToList();
            ViewData["ModelId"] = new SelectList(models, "Id", "Name");
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Name");
            return View();
        }
        [Authorize(Roles = Roles.Administrator)]
        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var porduct = mapper.Map<Product>(productVM);
                _context.Add(porduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var models = _context.Models.Include(q => q.ProductType.Make)
                .Select(q => new { Id = q.Id, Name = $"{q.ProductType.Make.Name} {q.ProductType.Name} {q.Name}" })
                .ToList();
            ViewData["ModelId"] = new SelectList(models, "Id", "Name", productVM.ModelId);
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Id", productVM.ConditionId);
            return View(productVM);
        }
        [Authorize(Roles = Roles.Administrator)]
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var productVM = mapper.Map<ProductVM>(product);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", product.ModelId);
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Name", product.ConditionId);
            return View(productVM);
        }
        [Authorize(Roles = Roles.Administrator)]
        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductVM productVM)
        {
            if (id != productVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var product = mapper.Map<Product>(productVM);
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productVM.Id))
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
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Id", productVM.ModelId);
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Id", productVM.ConditionId);
            return View(productVM);
        }
        [Authorize(Roles = Roles.Administrator)]
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [Authorize(Roles = Roles.Administrator)]
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}