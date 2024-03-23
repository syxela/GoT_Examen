using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Klassen
{
    public class Scoreboard
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public int Score {  get; set; }
        public DateTime Date { get; set; }

    }
}
