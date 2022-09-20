using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADNDetector.Clases.Analisis
{
    public class Mutante
    {
        private String[] Diago, DiagoInv, Rows, Colum;

        public Boolean isMutant(String[] dna)
        {
            Segmentacion(dna);



            if (Busqueda(Rows))
            {
                return true;
            }
            if (Busqueda(Colum))
            {
                return true;
            }
            if (Busqueda(DiagoInv))
            {
                return true;
            }

            return false;
        }

        private void Segmentacion(String[] dna)
        {

            String[] Filas = dna;
            Rows = dna;

            String[] Columnas = new String[Filas[0].Length];
            // Recorro las filas
            for (int f = 0; f < Filas.Length; f++)
            {
                // Recorro los caracteres de la fila
                for (int c = 0; c < Filas[f].Length; c++)
                {
                    // Inserto los datos en las columnas
                    Columnas[c] += Convert.ToString(Filas[f][c]);
                }
            }

            Colum = Columnas;

            String[] Diagonales = new String[Filas[0].Length + Filas.Length - 1];
            String[] DiagonalesInv = new String[Filas[0].Length + Filas.Length - 1];
            // Establezco las variables
            int col = 0;
            int ret = 0;
            int inc = 0;
            int diag = 0;
            int diagInv = 0;
            int addRow = 0;
            int addCol = 0;

            // Recorro las filas
            for (int f = 0; f < Filas.Length; f++)
            {

                // Si es la primer fila
                if (f == 0)
                {

                    // Recorro las columnas diagonal para atras
                    for (int c = col; c < Filas[0].Length; c++)
                    {

                        ret = c;
                        inc = f;
                        col = c;
                        addCol = c;
                        addRow = 0;


                        // recorro la diagonal
                        while (ret >= 0)
                        {
                            // si existe la fila agrego el carcter evitando salir del rango de filas existente.
                            if (Filas.Length > inc)
                            {
                                // Agrego el caracter 
                                Diagonales[diag] += Convert.ToString(Filas[inc][ret]);
                            }

                            // resto una columna
                            ret -= 1;
                            // sumo una fila
                            inc += 1;

                        }

                        while (addRow < Filas.Length)
                        {
                            if (addCol < Filas[0].Length)
                            {
                                DiagonalesInv[diagInv] += Convert.ToString(Filas[addRow][addCol]);
                            }
                            addRow += 1;
                            addCol += 1;
                        }

                        // Agrego diagonal invertida
                        diagInv += 1;
                        // Agrego una diagonal
                        diag += 1;

                    }
                }
                // si la fila es mayo a 0
                else
                {

                    inc = f;
                    // establesco cantidad de columnas
                    ret = Filas[0].Length - 1;

                    addCol = 0;
                    addRow = f;

                    // recorro las columnas
                    while (ret >= 0)
                    {
                        // si la fila esta dentro de las existentes
                        if (Filas.Length > inc)
                        {
                            Diagonales[diag] += Convert.ToString(Filas[inc][ret]);

                        }
                        // sumo una fila
                        inc += 1;
                        // resto una columna
                        ret -= 1;
                    }

                    // recorro diagnoles invertidas
                    while (addRow < Filas.Length)
                    {

                        DiagonalesInv[diagInv] += Convert.ToString(Filas[addRow][addCol]);

                        addRow += 1;
                        addCol += 1;
                    }
                    // sumo diagonal invertida
                    diagInv += 1;
                    // sumo una diagonal
                    diag += 1;

                }


            }
            Diago = Diagonales;
            DiagoInv = DiagonalesInv;
        }

        private Boolean Busqueda(String[] dna, int coincidencias = 4)
        {
            Boolean resultado = false;
            int cuenta = 0;
            string CaracterAnt = null;

            for (int f = 0; f < dna.Length; f++)
            {


                for (int c = 0; c < dna[f].Length; c++)
                {
                    if (c == 0)
                    {
                        CaracterAnt = Convert.ToString(dna[f][c]);
                        cuenta = 0;
                    }
                    if (CaracterAnt == Convert.ToString(dna[f][c]))
                    {
                        cuenta += 1;
                    }
                    else
                    {
                        cuenta = 0;
                    }

                    CaracterAnt = Convert.ToString(dna[f][c]);

                    if (cuenta >= coincidencias)
                    {
                        resultado = true;
                    }

                }

                CaracterAnt = null;

            }

            return resultado;
        }


    }
}
