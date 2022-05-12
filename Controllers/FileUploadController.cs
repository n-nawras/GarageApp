using GarageApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace GarageApp.Controllers
{
    public class FileUploadController : Controller
    {
        private IWebHostEnvironment Environment;
        private readonly ApplicationDbContext dbContext;

        public FileUploadController(IWebHostEnvironment environment, ApplicationDbContext dbContext)
        {
            this.Environment = environment;
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(string licensePlate, IFormFile file)

        {
            if (licensePlate == null)
            {
                return NotFound();
            }
            else if (!dbContext.Cars.Any(c => c.LicensePlate == licensePlate))
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
