using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartCookbook.Models;

namespace SmartCookbook.Data
{
    public class SmartCookbookContext : DbContext
    {
        public SmartCookbookContext (DbContextOptions<SmartCookbookContext> options)
            : base(options)
        {
        }

        public DbSet<SmartCookbook.Models.Recipe> Recipe { get; set; } = default!;
    }
}
