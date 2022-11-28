using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using DemoDMS.Models;

namespace DemoDMS.Controllers;

public class HomeController : Controller
{
    private readonly IStringLocalizer<HomeController> _localizer;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IStringLocalizer<HomeController> localizer, ILogger<HomeController> logger)
    {
        _localizer = localizer;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
