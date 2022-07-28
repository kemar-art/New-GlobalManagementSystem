using AutoMapper;
using GlobalManagementSystem.Web.Constants;
using GlobalManagementSystem.Web.Data;
using GlobalManagementSystem.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GlobalManagementSystem.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> userManager;
        private readonly IMapper mapper;

        public EmployeesController(ApplicationDbContext context, UserManager<Employee> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            _context = context;

        }

        // GET: EmplyeesController
        public async Task<IActionResult> Index()
        {
            var employees = userManager.Users.ToList();
            var model = mapper.Map<List<EmployeeVM>>(employees);
            return View(model);
        }

        // GET: EmplyeesController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var employees = await userManager.FindByIdAsync(id);
            var model = mapper.Map<EmployeeVM>(employees);
            return View(model);
        }

        // POST: EmplyeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmplyeesController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await userManager.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            var model = mapper.Map<EmployeeVM>(employee);
            return View(model);
        }

        // POST: EmplyeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, EmployeeVM employeeVM)
        {
            if (id != employeeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await userManager.FindByIdAsync(employeeVM.Id);
                    mapper.Map(employeeVM, user);
                    var result = await userManager.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employeeVM.Id))
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
            return View(employeeVM);
        }

        private bool EmployeeExists(string id)
        {
            throw new NotImplementedException();
        }

        // POST: EmployeeVM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }

}
