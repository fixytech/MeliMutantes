using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADNDetector.Models
{
    public class Test
    {

        public int Id { get; set; }
        public DateTime Creado { get; set; }
        public string Adn { get; set; }
        public Boolean Resultado { get; set; }

        public Test()
        {
            Creado = DateTime.Today;
        }
    }
}
