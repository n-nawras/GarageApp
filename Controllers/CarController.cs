using GarageApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageApp.Controllers{
    public class CarController : Controller
    {
        private ApplicationDbContext _context;

        public CarController(ApplicationDbContext context) {
            this._context = context;
        }

        public IActionResult Index(string? brand)
        {
            var cars = _context.Cars.AsQueryable();


            if (brand != null)
            {
                cars = cars.Where(c => c.Brand == brand);
            }

            var result = cars.ToList();


            return View(result);
        }

        public async Task<IActionResult> Details(string licensePlate)
        {

            var cars = await _context.Cars
                .FirstOrDefaultAsync(m => m.LicensePlate == licensePlate);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }




    }
}
