using System.Collections.Generic;

namespace GoT_Examen.Klassen
{
    public class House
    {
        public string slug { get; set; }
        public string name { get; set; }
    }

    public class Character
    {
        public string name { get; set; }
        public string slug { get; set; }
        public House house { get; set; }
        public List<string> quotes { get; set; }
    }

    public class CharacterImage
    {
        public string fullName { get; set; }
        public string imageUrl { get; set; }
    }
}
