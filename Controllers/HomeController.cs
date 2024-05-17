using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportStore.Data;
using SportStore.Models;
using System.Diagnostics;

namespace SportStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductContext _context;
        private readonly CartContext _context_cart;

        public HomeController(ILogger<HomeController> logger , ProductContext context, CartContext cart)
        {
            _logger = logger;
            _context = context;
            _context_cart = cart;
        }

        public async Task<IActionResult> Index() => View(await _context.Product.ToListAsync());
        public async Task<IActionResult> Chess() => View(await _context.Product.Where(m=>m.product_category =="Chess").ToListAsync());
        public async Task<IActionResult> Soccer() => View(await _context.Product.Where(m=>m.product_category =="Soccer").ToListAsync());
        public async Task<IActionResult> WaterSport() => View(await _context.Product.Where(m=>m.product_category =="Water Sport").ToListAsync());

        public IActionResult AddCart(int price, int qty , int product_id)
        {
            int total = price*qty;
            Cart cart = new Cart { product_id = product_id, total = total };
            _context_cart.Add(cart);
            _context.SaveChanges();
            
            return RedirectToAction("Index");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
