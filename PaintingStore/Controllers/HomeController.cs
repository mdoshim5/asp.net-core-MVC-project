using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaintingStore.Models;
using PaintingStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext databaseContext;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(DatabaseContext databaseContext, IHostingEnvironment hostingEnvironment, ILogger<HomeController> logger)
        {
            this.databaseContext = databaseContext;
            this.hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        public IActionResult Index(string? search)
        {
            var allPaints = databaseContext.PaintingView.ToList();
            if (string.IsNullOrEmpty(search))
            {
                return View(allPaints);
            }
            allPaints = allPaints.Where(x => x.Artist.Contains(search) || x.Name.Contains(search)).ToList();
            return View(allPaints);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreatePainting()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePainting(CreateViewForPaintings model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo != null)
                {
                    var uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    var filePath = Path.Combine(uploadFolder, uniqueFileName);
                    await model.Photo.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }
                var paint = new PaintingView()
                {
                    Name = model.Name,
                    Artist = model.Artist,
                    PhotoPath = uniqueFileName
                };
                var result = await databaseContext.AddAsync(paint);
                await databaseContext.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return View(model);
        }
        
    }
}
