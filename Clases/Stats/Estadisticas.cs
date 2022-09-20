using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADNDetector.Clases.Stats
{
    public class Estadisticas
    {
        public String Ratio(int valorUno, int valorDos)
        {
            int A = valorUno;
            int B = valorDos;
            var gcd = 0;

            if (valorUno != 0 && valorDos != 0)
            {
                gcd = GCD(A, B);
                return string.Format("{0}:{1}", A / gcd, B / gcd);
            }

            return string.Format("{0}:{1}", 0, 0);

        }
        static int GCD(int a, int b)
        {
            return b == 0 ? Math.Abs(a) : GCD(b, a % b);
        }

    }
}
