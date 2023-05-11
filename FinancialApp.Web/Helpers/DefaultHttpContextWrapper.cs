using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Web.Helpers;

public interface IHttpContextWrapper
{
    Task SignInAsync(Controller controller, ClaimsPrincipal principal);
    void SignOutAsync(Controller controller);
}

public class DefaultHttpContextWrapper : IHttpContextWrapper
{
    public async Task SignInAsync(Controller controller, ClaimsPrincipal principal)
    {
        await controller.HttpContext.SignInAsync(principal);
    }

    public async void SignOutAsync(Controller controller)
    {
        await controller.HttpContext.SignOutAsync();
    }
}
