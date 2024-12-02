using Microsoft.AspNetCore.Mvc;

namespace Validation;
[Route("Error")]
public class ErrorController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        int statusCode = HttpContext.Response.StatusCode;
        if(statusCode == 500)
        {
            return View("E500");
        }
        else if(statusCode == 404)
        {
            return View("E404");
        }

        return View(statusCode);
    }

}