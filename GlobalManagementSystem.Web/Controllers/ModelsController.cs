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
    public class ModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public ModelsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Models
        public async Task<IActionResult> Index()
        {
            var models = mapper.Map<List<ModelVM>>(await _context.Models.Include(m => m.ProductType).ToListAsync());
            return View(models);
        }

        // GET: Models/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models.Include(m => m.ProductType).FirstOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            var modelVM = mapper.Map<ModelVM>(model);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", model.ProductTypeId);
            return View(modelVM);
        }

        // GET: Models/Create
        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name");
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModelVM modelVM)
        {
            if (ModelState.IsValid)
            {
                var model = mapper.Map<Model>(modelVM);
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", modelVM.ProductTypeId);
            return View(modelVM);
        }

        // GET: Models/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            var modelVM = mapper.Map<ModelVM>(model);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", model.ProductTypeId);
            return View(modelVM);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ModelVM modelVM)
        {
            if (id != modelVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var model = mapper.Map<Model>(modelVM);
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(modelVM.Id))
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
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", modelVM.ProductTypeId);
            return View(modelVM);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Models
                .Include(m => m.ProductType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var model = await _context.Models.FindAsync(id);
                _context.Models.Remove(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private bool ModelExists(int id)
        {
            return _context.Models.Any(e => e.Id == id);
        }
    }
}
