using System.Security.Claims;
using System.Threading.Tasks;
using FinancialApp.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Tests.Helpers;

public class FakeHttpContextWrapper : IHttpContextWrapper
{
    public Task SignInAsync(Controller controller, ClaimsPrincipal principal) {
        return Task.CompletedTask;
    }

    public void SignOutAsync(Controller controller) {}
}