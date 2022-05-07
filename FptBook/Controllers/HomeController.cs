using FptBook.Areas.Identity.Data;
using FptBook.Data;
using FptBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FptBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly FptBookContext _context;
       
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<FptBookUser> _userManager;
        private readonly int _recordsPerPage = 20;

        public HomeController(ILogger<HomeController> logger, UserManager<FptBookUser> userManager, FptBookContext context)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }
        [Authorize(Roles = "Customer")]
        public IActionResult ForCustomerOnly()
        {
            ViewBag.message = "This is for Customer only! Hi " + _userManager.GetUserName(HttpContext.User);
            return View("Views/Home/Index.cshtml");           
        }
        [Authorize(Roles = "Seller")]
        public IActionResult ForSellerOnly()
        {
            ViewBag.message = "This is for Store Owner only!";
            return View("Views/Home/Index.cshtml");
        }
        public async Task<IActionResult> Index(int id, string searchString = "")
        {
            var books = _context.Book
            .Where(s => s.Title.Contains(searchString) || s.Category.Contains(searchString));
            FptBookUser thisUser = await _userManager.GetUserAsync(HttpContext.User);
           // Store thisStore = await _context.Store.FirstOrDefaultAsync(s => s.UId == thisUser.Id);
            int numberOfRecords = await books.CountAsync();     //Count SQL
            int numberOfPages = (int)Math.Ceiling((double)numberOfRecords / _recordsPerPage);
            ViewBag.numberOfPages = numberOfPages;
            ViewBag.currentPage = id;
            ViewData["CurrentFilter"] = searchString;
            List<Book> bookList = await books
                .Skip(id * _recordsPerPage)  //Offset SQL
                .Take(_recordsPerPage)       //Top SQL
                .ToListAsync();
            return View(bookList);
        }
        public async Task<IActionResult> Privacy()
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