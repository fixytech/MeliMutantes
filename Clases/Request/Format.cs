using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADNDetector.Clases.Request
{
    public class Format
    {
        public String[] Objeto(string value)
        {

            string sinComillas = value.Replace('"', ' ');
            string sinEspacios = sinComillas.Replace(" ", String.Empty);
            string[] sinLlaveUno = sinEspacios.Split('{');
            string[] sinLlaveDos = sinLlaveUno[1].Split('}');


            String[] Filas = sinLlaveDos[0].Split(',');

            return Filas;
        }
        public String Array(string value)
        {

            string Uno = value.Replace('[', '{');
            string Dos = Uno.Replace(']', '}');

            return Dos;
        }
    }
}
