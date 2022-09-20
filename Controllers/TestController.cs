using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADNDetector.Clases.Objetos;
using ADNDetector.Clases.Request;
using ADNDetector.Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ADNDetector.Models;
using ADNDetector.Models.Repository;

namespace ADNDetector.Controllers
{
    public class TestController : Controller
    {
        private static ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        // GET: Test
        public ActionResult Estadisticas()
        {
            // Instancio la clase
            Clases.Test Test = new Clases.Test();
            //Creo un nuevo test y obtengo el resultado
            Estadistica Estadistica = Test.Stats(_testRepository.CantHumanos(), _testRepository.CantMutantes());

            ViewBag.CantHumanos = Estadistica.count_human_dna;
            ViewBag.CantMutantes = Estadistica.count_mutant_dna;
            ViewBag.Ratio = Estadistica.ratio;

            return View();
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                //Validacion
                // Instancio la clase de validacion
                Condiciones condiciones = new Condiciones();
                // Resultado de validacion
                Boolean Validacion = condiciones.FomatoRequestObjeto(collection["inputAdn"]);

                // Si el formato del string es invalido retorno error a la vista.
                if (!Validacion)
                {
                    ViewBag.Tipo = "warning";
                    ViewBag.Message = new String[] {
                    "Resultado: Formato de ADN invalido.",
                    "ADN Analizado: " + Convert.ToString(collection["inputAdn"])
    };
                    ViewBag.Status = 403;

                    return View();
                }

                // Formateo el string
                Format format = new Format();
                String[] dna = format.Objeto(collection["inputAdn"]);

                // Instancio la clase
                Clases.Test Test = new Clases.Test();
                //Creo un nuevo test y obtengo el resultado
                Boolean Resultado = Test.Create(dna);


                // creo el modelo con el resultado

                await _testRepository.CreateTestAsync(new Models.Test()
                {
                    Adn = collection["inputAdn"],
                    Resultado = Resultado,
                }
                 );

                ViewBag.Tipo = Resultado ? "danger" : "info";
                ViewBag.Message = new String[] { Resultado ? "ADN Mutante" : "ADN Humano" };

                return View();

            }
            catch (Exception e)
            {
                ViewBag.Tipo = "danger";
                ViewBag.Message = e;
                ViewBag.Status = 201;
                return View();
            }
        }

    }
}