using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyApp.CustomeToken;
using MyApp.DAL.InfraStructure.IRepository;
using MyApp.Models.Models;
using MyApp.Models.ViewModels;

namespace MyApp.Controllers;

public class UserController(IAccessAllRepo repo,ITokenManager tokenManager) : Controller
{
    // GET
    public IActionResult LoginPage()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginPage(User user)
    {
        if (user.Email == "" && user.Password == "") return NotFound();

        User? getUser = await repo.UserRepo.GetDataById(x => x.Email.Equals(user.Email) && x.IsActive,new List<string?> { "Roles" });

        if (getUser is null) return NotFound();

        if (getUser.Email == user.Email && getUser.Password == user.Password && getUser.IsActive)
        {
            var token = await tokenManager.NewToken();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("Authorization", token.Value!),
            };
            claims.AddRange(getUser.Roles.Select(role => 
                new Claim(ClaimTypes.Role,role!.RoleName)));
            var claimsIdentity = new ClaimsIdentity(claims, 
                CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                claimsPrincipal);
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpGet]
    public IActionResult AccessDeniedPage()
    {
        return View();
    }

    [HttpGet]
    public IActionResult RegisterPage()
    {
        return View();
    }
}