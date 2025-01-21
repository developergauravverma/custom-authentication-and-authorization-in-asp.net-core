using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Middleware;

namespace MyApp.Controllers;
[CustomeAuthenticationFilter]
[Authorize(Roles = "Admin")]
public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}