using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoDMS.Models;

namespace DemoDMS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Upload(){
        return View();
    }

    [HttpPost("FileUpload")]
    public async Task<IActionResult> UploadToFileSystem(List<IFormFile> files)
    {
        long size = files.Sum(f => f.Length);
                        
        var filePaths = new List<string>();
        foreach (var file in files)
        {
        var basePath = Path.Combine(Directory.GetCurrentDirectory() , "Documents");
        bool basePathExists = System.IO.Directory.Exists(basePath);
        if (!basePathExists) Directory.CreateDirectory(basePath);
        var fileName = Path.GetFileNameWithoutExtension(file.FileName);
        var filePath = Path.Combine(basePath, file.FileName);
        var extension = Path.GetExtension(file.FileName);
        if (!System.IO.File.Exists(filePath))
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

        }
        }
        // process uploaded files
        // Don't rely on or trust the FileName property without validation.
        return Ok(new { count = files.Count, size, filePaths });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
