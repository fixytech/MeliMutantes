using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADNDetector.Clases.Request
{
    public class Condiciones
    {

        public Boolean FomatoRequestObjeto(String value)
        {
            Regex regex = new Regex("\\{\"[ATGC][ATGC][ATGC][ATGC][ATGC][ATGC]\",\"[ATGC][ATGC][ATGC][ATGC][ATGC][ATGC]\",\"[ATGC][ATGC][ATGC][ATGC][ATGC][ATGC]\",\"[ATGC][ATGC][ATGC][ATGC][ATGC][ATGC]\",\"[ATGC][ATGC][ATGC][ATGC][ATGC][ATGC]\",\"[ATGC][ATGC][ATGC][ATGC][ATGC][ATGC]\"\\}", RegexOptions.IgnoreCase);
            return regex.IsMatch(value);
        }
        public Boolean FomatoRequestArray(String value)
        {
            Regex regex = new Regex("\\[\"[ATGC][ATGC][ATGC][ATGC][ATGC][ATGC]\",\"[ATGC][ATGC][ATGC][ATGC][ATGC][ATGC]\",\"[ATGC][ATGC][ATGC][ATGC][ATGC][ATGC]\",\"[ATGC][ATGC][ATGC][ATGC][ATGC][ATGC]\",\"[ATGC][ATGC][ATGC][ATGC][ATGC][ATGC]\",\"[ATGC][ATGC][ATGC][ATGC][ATGC][ATGC]\"\\]", RegexOptions.IgnoreCase);
            return regex.IsMatch(value);
        }
    }
}
