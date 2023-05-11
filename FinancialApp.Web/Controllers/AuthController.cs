using System.Security.Claims;
using FinancialApp.Web.DB;
using FinancialApp.Web.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Web.Controllers;

public class AuthController : Controller
{
    private readonly IHttpContextWrapper _httpContextWrapper;

    public AuthController(IHttpContextWrapper httpContextWrapper)
    {
        _httpContextWrapper = httpContextWrapper;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // si el usuario existe en la base de datos generar la cookie, caso contrario mostrar mensaje de usaurio o password erroneo

        if (DbEntities.Usuarios.Any(x => x.Username == username && x.Password == password))
        {
            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, username),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            _httpContextWrapper.SignInAsync(this, claimsPrincipal);
            
            return RedirectToAction("Index", "Cuenta");
        }
        
        ModelState.AddModelError("AuthError", "Usuario y/o contraseña erronea");
        return View();
    }

    [HttpGet]
    public IActionResult Logout()
    {
        _httpContextWrapper.SignOutAsync(this);
        return RedirectToAction("Login");
    }
}