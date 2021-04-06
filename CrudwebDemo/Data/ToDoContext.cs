using CrudwebTODO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudwebTODO.Data
{
    public class ToDoContext: DbContext
    {
        public DbSet<TODOlist> TODOlists { get; set; }
        public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options)
        { }
    }
}
