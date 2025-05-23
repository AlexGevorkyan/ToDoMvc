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
    public class TodosController : Controller
    {
        private readonly ToDoContext _context;

        public TodosController(ToDoContext context)
        {
            _context = context;
        }

        // GET: Todos
        public async Task<IActionResult> Index()
        {
            IQueryable<Todo> toDoContext = _context.Todo.Include(t => t.User);
            return View(await toDoContext.ToListAsync());
        }
    }
}
