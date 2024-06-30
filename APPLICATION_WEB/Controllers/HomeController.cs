using APPLICATION_WEB.Data;
using APPLICATION_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace APPLICATION_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Users.ToList());
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

        [HttpPost]
        public async Task<JsonResult> AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                await _context.AddUser(user);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<JsonResult> EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                var existingPerson = _context.Users.Find(user.Id);
                if (existingPerson != null)
                {
                    existingPerson.Name = user.Name;
                    existingPerson.Email = user.Email;
                    existingPerson.Phone = user.Phone;
                    existingPerson.Address = user.Address;
                    existingPerson.State = user.State;
                    existingPerson.City = user.City;

                    await _context.EditUser(user);
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }

        [HttpDelete]
        public async Task<JsonResult>DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return Json(new { success = false });
            }
            await _context.DeleteUser(id);
            return Json(new { success = true });
        }
    }
}