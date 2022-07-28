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
    [Authorize(Roles = "Administrator, User")]
    public class InventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public InventoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        // GET: Inventories
        public async Task<IActionResult> Index()
        {
            var inventorys = mapper.Map<List<InventoryVM>>(await _context.Inventorys.Include(i => i.Product.Model.ProductType.Make).ToListAsync());
            return View(inventorys);
        }
        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventorys.Include(i => i.Product.Model.ProductType.Make)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            var inventoryVM = mapper.Map<InventoryVM>(inventory);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", inventory.ProductId);
            return View(inventoryVM);
        }
        [Authorize(Roles = Roles.Administrator)]
        // GET: Inventories/Create
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
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryVM inventoryVM)
        {
            if (ModelState.IsValid)
            {
                var inventory = mapper.Map<Inventory>(inventoryVM);
                _context.Add(inventory);
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
            ViewData["ProductId"] = new SelectList(products, "Id", "Name", inventoryVM.ProductId);
            return View(inventoryVM);
        }
        [Authorize(Roles = Roles.Administrator)]
        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventorys.FindAsync(id);
            if (inventory == null)
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
            var inventoryVM = mapper.Map<InventoryVM>(inventory);
            ViewData["ProductId"] = new SelectList(products, "Id", "Name", inventory.ProductId);
            return View(inventoryVM);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InventoryVM inventoryVM)
        {
            if (id != inventoryVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var inventory = mapper.Map<Inventory>(inventoryVM);
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventoryVM.Id))
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
            ViewData["ProductId"] = new SelectList(products, "Id", "Id", inventoryVM.ProductId);
            return View(inventoryVM);
        }
        [Authorize(Roles = Roles.Administrator)]
        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventorys
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }
        [Authorize(Roles = Roles.Administrator)]
        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var inventory = await _context.Inventorys.FindAsync(id);
                _context.Inventorys.Remove(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventorys.Any(e => e.Id == id);
        }
    }
}