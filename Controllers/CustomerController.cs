using ITIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITIProject.Controllers
{
    public class CustomerController : Controller
    {
        ECommerceAContextApp _context = new ECommerceAContextApp();
        public IActionResult Browse()
        {
            ViewBag.categories = _context.Categories.ToList();   
            return View(_context.Products.ToList());
        }

       public IActionResult ViewCart()
        {
            ViewBag.categories = _context.Categories.ToList();
            return View(_context.ProductOrders.Where(po => po.CartId == 7).ToList());
        }


        public IActionResult RemoveFromCart(ProductOrder po, [FromRoute] int id)
        {
            _context.ProductOrders.Remove(po);
            _context.SaveChanges();
            return RedirectToAction("ViewCart");
        }


        public IActionResult MakeOrder(List<ProductOrder> productOrders)
        {
            var order = new Order();
            return View();
        }

        public IActionResult AddToCart(Product product, [FromRoute] int Id)
        {
            var productPrice = _context.Products.Find(Id).Price; ;
            if (_context.ProductOrders.Any(po => po.ProductId== Id))
            {
                AddRepeatedItem(Id, productPrice);
            }
            else
            {
                ProductOrder productOrder = new ProductOrder();
                productOrder.Quantity += 1;
                productOrder.ProductId = Id;
                productOrder.Cost = productPrice;
                productOrder.CartId = 7;
                _context.ProductOrders.Update(productOrder);

            }

            _context.Products.Find(product.Id).Quantity -= 1;          
            _context.SaveChanges();
            return RedirectToAction("Browse");
        }

        //public IActionResult AddToCart(Product product, [FromRoute] int Id)
        //{
        //    ProductOrder productOrder = new ProductOrder();
        //    _context.Products.Find(product.Id).Quantity -= 1;
        //    productOrder.Quantity += 1;
        //    productOrder.ProductId =Id;
        //    productOrder.Cost = _context.Products.Find(Id).Price;
        //    productOrder.CartId = 7;
        //    _context.ProductOrders.Update(productOrder);
        //    _context.SaveChanges();
        //    return RedirectToAction("Browse");            
        //}

        public void AddRepeatedItem(int id, decimal cost)
        {
            var item = _context.ProductOrders.FirstOrDefault(po => po.ProductId == id);
            item.Quantity += 1;
            item.Cost += cost;
        }
    }

    
}
