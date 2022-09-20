
using ADNDetector.Clases.Analisis;
using ADNDetector.Clases.Objetos;
using ADNDetector.Clases.Stats;
using ADNDetector.Models.Repository;
using ADNDetector.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ADNDetector.Clases
{
    public class Test
    {

        public Boolean Create(String[] inputAdn)
        {

            try
            {

                // Instancio la clase que analizara si es mutante
                Analisis.Mutante Analisis = new Analisis.Mutante();

                return Analisis.isMutant(inputAdn);

            }
            catch (Exception e)
            {
                throw new Exception("Ops! algo salio mal.", e);
            }

        }

        public Estadistica Stats(int CantHumanos = 0, int CantMutantes = 0)
        {

            Estadisticas estadisticas = new Estadisticas();
            Estadistica estadistica = new Estadistica();

            estadistica.count_human_dna = CantHumanos;
            estadistica.count_mutant_dna = CantMutantes;
            estadistica.ratio = estadisticas.Ratio(CantHumanos, CantMutantes);

            return estadistica;

        }
    }
}
