using ITIProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System.Linq.Expressions;

namespace ITIProject.Controllers
{
    public class AdminestratorController : Controller
    {
        ECommerceAContextApp _context = new ECommerceAContextApp();
        private readonly IWebHostEnvironment _webHostEnvironment ;



        public AdminestratorController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public IActionResult AllItems()
        {

            //ViewBag.categories = _context.Categories.Select(c => c.Name).ToList();
            return View(_context.Products.ToList());
        }
        [HttpGet]

        public IActionResult NewItem()
        {
            ViewBag.categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult NewItem(Product product, [FromRoute] int Id)
        {
            IFormFile imageFile = Request.Form.Files["imageFile"];
            if (product.Name != null)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                    product.ImagePath = "/Images/" + fileName;
                }
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("AllItems");
            }
            ViewBag.categories = _context.Categories.ToList();
            return View(product);
        }


        [HttpGet]
        public IActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewCategory(Category category)
        {
            if(category.Name != null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("AllItems");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.categories = _context.Categories.ToList();
            var product =  _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        //IFormFile imageFile = Request.Form.Files["imageFile"];
        public IActionResult Update(Product product, IFormFile imageFile)
        {
            
             
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                    product.ImagePath = "/Images/" + fileName;
                }
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("AllItems");
            }
            ViewBag.categories = _context.Categories.ToList() ;
            return View(product);
        }

        [HttpGet]
        public ActionResult DeleteItem(int id)
        {
            var product = _context.Products.Find(id);
            ViewBag.category = _context.Categories.Find(product.CategoryId).Name;
            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteItem(Product product)
        {
            
            
                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction("AllItems");
        }



        //public IActionResult LogIn()
        //{
        //    return View(/*_context.Adminestrator.ToList()*/);
        //}

        //public IActionResult ConfirmAdmin(Adminestrator a, [FromRoute] int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            return RedirectToAction("AllItems");
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("Password", "Wrong Password");
        //            return RedirectToAction("LogIn",a);
        //        }

        //    }
        //    else
        //        return RedirectToAction("LogIn",a);
        //}

        //public IActionResult ValidateAdminIdentity(string Password, string Name)
        //{
        //    var admin = _context.Adminestrator.FirstOrDefault(a => a.Password == Password && a.Name == Name);

        //    if (admin == null)
        //    {
        //        return Json(false);
        //    }
        //    else
        //        return Json(true);
        //}
    }
}
