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
        
        public CarAdminController(
            IWebHostEnvironment environment,
            ApplicationDbContext context)
        {
            this.Environment = environment;

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
        public async Task<IActionResult> EditAsync(Car car)
        {
            var existingCar = await _context.Cars.FindAsync(car.LicensePlate);
            existingCar.Brand = car.Brand;
            existingCar.Odometer = car.Odometer;
            existingCar.SalesPrice = car.SalesPrice;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        private IWebHostEnvironment Environment;

    

        [HttpPost]
        public async Task<IActionResult> UploadFile(string licensePlate, IFormFile file)

        {
            if (licensePlate == null)
            {
                return NotFound();
            }
            else if (!_context.Cars.Any(c => c.LicensePlate == licensePlate))
            {
                return NotFound();
            }
            else
            {

                var carImagePath = Path.Join(
                Environment.WebRootPath, "Cars", licensePlate, "Images"
                    );

                if (!Directory.Exists(carImagePath))
                {
                    Directory.CreateDirectory(carImagePath);
                }

                if (file != null)
                {
                    var filePath = Path.Join(carImagePath, file.FileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }

                }

                return Ok();
            }


        }
    }
}