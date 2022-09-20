using ADNDetector.Models.Repository;
using ADNDetector.Clases.Objetos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using ADNDetector.Clases.Request;
using Newtonsoft.Json;

namespace ADNDetector.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MutantController : ControllerBase
    {
        private static ITestRepository _testRepository;

        public MutantController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] Adn cadena)
        {
            // Instancio la clase de validacion
            Condiciones condiciones = new Condiciones();
            // Resultado de validacion
            Boolean Validacion = condiciones.FomatoRequestArray(JsonConvert.SerializeObject(cadena.dna));

            // Si el formato del string es invalido retorno error 
            if (!Validacion)
            {
                return BadRequest(new ApiResponse() { status = 403, message = "Formato invalido." });

            }

            // Formateo el json
            Format format = new Format();
            String dna = format.Array(JsonConvert.SerializeObject(cadena.dna));

            // Instancio la clase
            Clases.Test Test = new Clases.Test();
            //Creo un nuevo test y obtengo el resultado
            Boolean Resultado = Test.Create(cadena.dna);


            // creo el modelo con el resultado

            await _testRepository.CreateTestAsync(new Models.Test()
            {
                Adn = dna,
                Resultado = Resultado,
            }
             );
            if (Resultado)
            {
                return new ObjectResult(new ApiResponse() { status = 403, message = "Mutante" }) { StatusCode = 403 };
            }
            return Ok(new ApiResponse() { status = 200, message = "Humano" });
        }
    }
}
