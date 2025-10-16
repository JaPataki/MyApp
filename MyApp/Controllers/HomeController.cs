using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.DataLayer.Entities;
using MyApp.DataLayer;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MyApp.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            UserEntity user = new UserEntity();
            _logger = logger;
            _context = context;
        }

        public IActionResult UserDetail(Guid userPublicId) 
        {
            var user = _context.Users
                                .FirstOrDefault(u => u.PublicId == userPublicId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View(new CreateUserModel());
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserModel user)
        {
            var entity = new UserEntity()
            {
                Email = user.Email,
                Name = user.UserName,
                PublicId = Guid.NewGuid()

            };

            _context.Users.Add(entity);
            _context.SaveChanges();
            return RedirectToAction("Users");
        }

        public IActionResult Users()
        {
            var userList = _context.Users.ToList();

            return View(userList);
        }

        public IActionResult Index()
        {
            return View();
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
