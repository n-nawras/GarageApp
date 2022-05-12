using GarageApp.Data;
using GarageApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GarageApp.Controllers
{
    public class CarAdminController : Controller
    {
        private ApplicationDbContext _context;

        public CarAdminController(ApplicationDbContext context)
        {
            this._context = context;
        }


        public IActionResult Index()
        {
            var cars = _context.Cars.ToList();
            return View(cars);
        }

        public async Task<IActionResult> Details(string? LicensePlate)
        {
            if (LicensePlate == null)
            {
                return RedirectToAction("Index");
            }

            var cars = await _context.Cars
                .FirstOrDefaultAsync(m => m.LicensePlate == LicensePlate);
            if (cars == null)
            {
                return RedirectToAction("Index");
            }

            return View(cars);

        }

        [HttpPost]
        public IActionResult Edit()
        {
            var cars = _context.Cars.ToList();
            return View(cars);

        }

    }
}