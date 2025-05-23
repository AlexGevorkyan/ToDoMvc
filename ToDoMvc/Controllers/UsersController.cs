using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoMvc.Data;
using ToDoMvc.Models;

namespace ToDoMvc.Controllers
{
    public class UsersController : Controller
    {
        private readonly ToDoContext _context;

        public UsersController(ToDoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }
        // -----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        // -----------------------------------------------------------------------
        // Наступний метод забирає дані із цієї форми і обробляє їх :
        [HttpPost]
        public IActionResult Register(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        // -----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        // -----------------------------------------------------------------------
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            User user = _context.User.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            if (user == null)
            {
                return View();  // якщо юзер не залогінився, то тоді відправлю його знову на форму логіну
            }
            else  // якщо юзер успішно залогінився
            {
                /* Я зараз створимо сесію, і в сесію запишемо ідентифікатор юзера і його ім’я. 
                   Спочатку звернуся до класу HttpContext до проперті Session. 
                   Зараз ми в сесію запишу Id-шник юзера як key-value-пару. 
                   Ключ назову LoggedId, а в якості значення записую Id-шник юзера :     */
                HttpContext.Session.SetInt32("LoggedId", user.Id);

                HttpContext.Session.SetString("LoggedId", user.Email);

                return RedirectToAction("Index");
            }
        }
        // -----------------------------------------------------------------------
    }
}
