
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADNDetector.Clases.Objetos
{
    public class Respuesta
    {
        [Required]
        public string Tipo { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]

        public string[] Message { get; set; }
        [Required]

        public string Analisis { get; set; }

        [Required]

        public Boolean Resultado { get; set; }

    }
}
