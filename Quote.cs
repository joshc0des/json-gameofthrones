using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_P_GameOfThronesQuote
{
    public class Quote
    {
        public string sentence { get; set; }
        public character character { get; set; }

        public override string ToString()
        {
            return $"\"{sentence}\" - {character.name}";
        }
    }

    public class character
    {
        public string name { get; set; }
        public string slug { get; set; }
        public house house { get; set; }
    }

    public class house
    {
        public string name { get; set; }
        public string slug { get; set; }
    }
}
