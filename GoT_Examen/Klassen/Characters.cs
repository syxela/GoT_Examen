using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoT_Examen.Klassen
{
    public class Characters
    {
        public string Name { get; set; }
        public House House { get; set; }
        public List<string> Quotes { get; set; }
    }

    public class House
    {
        public string Name { get; set; }
    }

    public class CharacterImage
    {
        public string FullName { get; set; }
        public string Image { get; set; }
        public string ImageUrl { get; set; }
    }
}
