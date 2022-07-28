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
    public class RestocksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public RestocksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Restocks
        public async Task<IActionResult> Index()
        {
            var restocks = mapper.Map<List<RestockVM>>(await _context.Restocks.Include(r => r.Product.Model.ProductType.Make).Include(r => r.Supplier).ToListAsync());
            return View(restocks);
        }

        // GET: Restocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restock = await _context.Restocks
                .Include(r => r.Product.Model.ProductType.Make)
                .Include(r => r.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restock == null)
            {
                return NotFound();
            }

            var restockVM = mapper.Map<RestockVM>(restock);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", restock.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Id", restock.SupplierId);
            return View(restockVM);
        }

        // GET: Restocks/Create
        public IActionResult Create()
        {
            var products = _context.Products.Include(q => q.Model.ProductType.Make)
               .Select(q => new
               {
                   Id = q.Id,
                   Name = $"{q.Model.ProductType.Make.Name} | " +
               $"{q.Model.ProductType.Name} | {q.Model.Name} {q.Name}"
               })
               .ToList();
            ViewData["ProductId"] = new SelectList(products, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            return View();
        }

        // POST: Restocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RestockVM restockVM)
        {
            if (ModelState.IsValid)
            {
                var restock = mapper.Map<Restock>(restockVM);
                _context.Add(restock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var products = _context.Products.Include(q => q.Model.ProductType.Make)
               .Select(q => new
               {
                   Id = q.Id,
                   Name = $"{q.Model.ProductType.Make.Name} " +
               $"{q.Model.ProductType.Name} {q.Model.Name} {q.Name}"
               })
               .ToList();
            ViewData["ProductId"] = new SelectList(products, "Id", "Name", restockVM.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Name", "Name", restockVM.SupplierId);
            return View(restockVM);
        }

        // GET: Restocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restock = await _context.Restocks.FindAsync(id);
            if (restock == null)
            {
                return NotFound();
            }
            var products = _context.Products.Include(q => q.Model.ProductType.Make)
              .Select(q => new
              {
                  Id = q.Id,
                  Name = $"{q.Model.ProductType.Make.Name} | " +
              $"{q.Model.ProductType.Name} | {q.Model.Name} {q.Name}"
              })
              .ToList();
            var restockVM = mapper.Map<Restock>(restock);
            ViewData["ProductId"] = new SelectList(products, "Id", "Name", restock.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", restock.SupplierId);
            return View(restockVM);
        }

        // POST: Restocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RestockVM restockVM)
        {
            if (id != restockVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var restock = mapper.Map<Restock>(restockVM);
                    _context.Update(restock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestockExists(restockVM.Id))
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
            var products = _context.Products.Include(q => q.Model.ProductType.Make)
             .Select(q => new
             {
                 Id = q.Id,
                 Name = $"{q.Model.ProductType.Make.Name} " +
             $"{q.Model.ProductType.Name} {q.Model.Name} {q.Name}"
             })
             .ToList();
            ViewData["ProductId"] = new SelectList(products, "Id", "Id", restockVM.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Id", restockVM.SupplierId);
            return View(restockVM);
        }

        // GET: Restocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restock = await _context.Restocks
                .Include(r => r.Product)
                .Include(r => r.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restock == null)
            {
                return NotFound();
            }

            return View(restock);
        }

        // POST: Restocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var restock = await _context.Restocks.FindAsync(id);
                _context.Restocks.Remove(restock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private bool RestockExists(int id)
        {
            return _context.Restocks.Any(e => e.Id == id);
        }
    }
}
