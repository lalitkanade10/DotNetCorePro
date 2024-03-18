using Microsoft.EntityFrameworkCore;
using UnitOFWorkPattern.Model;

namespace UnitOFWorkPattern.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

        public DbSet<ToDo> ToDo { get; set; }
    }
}
