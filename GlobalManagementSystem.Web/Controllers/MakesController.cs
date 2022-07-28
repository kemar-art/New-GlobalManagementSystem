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
    public class MakesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public MakesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
            var makes = mapper.Map<List<MakeVM>>(await _context.Makes.ToListAsync());
            return View(makes);
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var make = await _context.Makes.FirstOrDefaultAsync(m => m.Id == id);
            if (make == null)
            {
                return NotFound();
            }

            var makeVM = mapper.Map<MakeVM>(make);
            return View(makeVM);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MakeVM makeVM)
        {
            if (ModelState.IsValid)
            {
                var make = mapper.Map<Make>(makeVM);
                _context.Add(make);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(makeVM);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var make = await _context.Makes.FindAsync(id);
            if (make == null)
            {
                return NotFound();
            }

            var makeVM = mapper.Map<MakeVM>(make);
            return View(makeVM);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MakeVM makeVM)
        {
            if (id != makeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var make = mapper.Map<Make>(makeVM);
                    _context.Update(make);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(makeVM.Id))
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
            return View(makeVM);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var make = await _context.Makes.FirstOrDefaultAsync(m => m.Id == id);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var make = await _context.Makes.FindAsync(id);
                _context.Makes.Remove(make);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private bool BrandExists(int id)
        {
            return _context.Makes.Any(e => e.Id == id);
        }
    }
}