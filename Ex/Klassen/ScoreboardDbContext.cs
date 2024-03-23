using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Klassen
{
    public class ScoreboardDbContext : DbContext
    {
        public ScoreboardDbContext()
        {
        }
        public DbSet<Scoreboard> Scoreboards { get; set; }
        
    }
}
