using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoMvc.Models;

namespace ToDoMvc.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext (DbContextOptions<ToDoContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoMvc.Models.User> User { get; set; } = default!;
        public DbSet<ToDoMvc.Models.Todo> Todo { get; set; } = default!;
    }
}
