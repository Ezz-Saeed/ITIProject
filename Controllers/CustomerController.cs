using ITIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITIProject.Controllers
{
    public class CustomerController : Controller
    {
        ECommerceAContextApp _context = new ECommerceAContextApp();
        public IActionResult Browse()
        {
            
            return View(_context.Products.ToList());
        }
    }
}
