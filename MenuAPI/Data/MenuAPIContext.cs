using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MenuAPI.Models;

namespace MenuAPI.Data
{
    public class MenuAPIContext : DbContext
    {
        public MenuAPIContext (DbContextOptions<MenuAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MenuAPI.Models.Menu> Menu { get; set; } = default!;
    }
}
