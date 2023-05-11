using System;
using System.Security.Claims;
using System.Threading.Tasks;
using FinancialApp.Tests.Helpers;
using FinancialApp.Web.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace FinancialApp.Tests.Controllers;

public class AuthControllerTest
{
    [Test]
    public void Test01()
    {
        var controller = new AuthController(new FakeHttpContextWrapper());
        var result = controller.Login("admin", "123456");
        
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        
    }
}