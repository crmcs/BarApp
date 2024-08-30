using Microsoft.AspNetCore.Mvc;
using BarApp.Models;
using BarApp.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BarApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Menu()
        {
            var cocktails = _context.Cocktails.ToList();
            return View(cocktails); // Returns the "Menu.cshtml" view with a list of cocktails
        }

        [HttpGet]
        public IActionResult PlaceOrder(int id)
        {
            var cocktail = _context.Cocktails.Find(id);
            return View(cocktail); // Returns the "PlaceOrder.cshtml" view with the selected cocktail
        }

        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("OrderQueue"); // Redirect to the order queue after placing the order
            }
            return View(order); // If validation fails, re-display the form
        }

        [HttpGet]
        public IActionResult OrderQueue()
        {
            var orders = _context.Orders.Include(o => o.Cocktail).ToList();
            return View(orders); // Returns the "OrderQueue.cshtml" view with a list of orders
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
