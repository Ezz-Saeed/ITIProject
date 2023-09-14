using ITIProject.Models;
using ITIProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITIProject.Controllers
{
    public class CustomerController : Controller
    {
        ECommerceAContextApp _context = new ECommerceAContextApp();

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            if(ModelState.IsValid)
            {
                var cart = new Cart();
                _context.Carts.Add(cart);
                _context.SaveChanges();
                customer.CartId = cart.Id;
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("LogIn");
            }
            return View(customer);
        }

        public IActionResult AgeValidation(int Age)
        {
            if (Age >= 18)
                return Json(true);
            return Json(false);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(Customer customer, [FromRoute] int CartId)
        {
           
            if (ModelState.IsValid)
            {
                return RedirectToAction("Browse", new { CartId = CartId });
            }
            return View(customer);
        }

        public IActionResult Browse()
        {
            ViewBag.categories = _context.Categories.ToList();   
            return View(_context.Products.ToList());
        }

       public IActionResult ViewCart()
        {
            ViewBag.categories = _context.Categories.ToList();
            return View(_context.ProductOrders.Where(po => po.CartId == 5).ToList());
        }


        public IActionResult RemoveFromCart(ProductOrder po, [FromRoute] int id)
        {
            _context.ProductOrders.Remove(po);
            _context.SaveChanges();
            return RedirectToAction("ViewCart");
        }


        public IActionResult MakeOrder(int Id)
        {
            FinalInvoiceViewModel invoice = new FinalInvoiceViewModel();
            var targetItems = _context.ProductOrders.Where(po => po.CartId == Id);
            decimal TotalCost = targetItems.Sum(po => po.Cost);
            var totalQuantity = targetItems.Sum(po => po.Quantity);
            var products = _context.Products.ToList();

            var order = new Order();
            foreach(var item in targetItems)
            {
                var Name = products.FirstOrDefault(p => p.Id == item.ProductId).Name;
                var Cost = item.Cost;
                var Quantity = item.Quantity;
                var finalItem = new ItemViewModel();
                finalItem.ItemCost = Cost;
                finalItem.ItemQuantity = Quantity;
                finalItem.ItemName = Name;
                invoice.Items.Add(finalItem);
            }
        
            order.TotalQuantity = totalQuantity;
            order.TotalCost = TotalCost;
            order.CartId = Id;
            invoice.TotalCost = TotalCost;
            invoice.CartId = Id;
            invoice.TotalQuantity = totalQuantity;
            _context.Orders.Add(order);
            _context.ProductOrders.RemoveRange(targetItems);
            _context.SaveChanges();
            invoice.OrderId = order.Id;
            return View(invoice);
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
                productOrder.CartId = 5;
                _context.ProductOrders.Update(productOrder);

            }

            _context.Products.Find(product.Id).Quantity -= 1;          
            _context.SaveChanges();
            return RedirectToAction("Browse");
        }

        public void AddRepeatedItem(int id, decimal cost)
        {
            var item = _context.ProductOrders.FirstOrDefault(po => po.ProductId == id);
            item.Quantity += 1;
            item.Cost += cost;
        }
    }

    
}
