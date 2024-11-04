using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Assignment2
{
public class HomeController : Controller
{
    [Route("")]
    [Route("index")]
    public IActionResult Index() 

    {
        //add stuff here that view requires
        //viewdata title only atm
        //add model here
        ViewData["title"] = "Home";
         return View(); 

    }
    [Route("Contact")]
    [HttpPost]
    public IActionResult Contact(ContactModel model) 
    {
        Console.WriteLine("Hello World!");
        Console.WriteLine("first name: " + model.FirstName);

        return View(model); 

    }
    [Route("ContactHTML")]
    public IActionResult ContactHTML() 
    {
        //add stuff here that view requires
        //viewdata title only atm
         ViewData["title"] = "Contact HTML";
         return View(); 
 
    }

    [Route("ContactTagHelper")]
    public IActionResult ContactTagHelper() 
    {
        //add stuff here that view requires
        //viewdata title only atm
         ViewData["title"] = "Contact TagHelper";
         return View(); 
 
    }
    

}
}