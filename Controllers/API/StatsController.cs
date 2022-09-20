using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ADNDetector.Models;
using ADNDetector.Models.Repository;
using ADNDetector.Clases.Objetos;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ADNDetector.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private static ITestRepository _testRepository;

        public StatsController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        // GET: api/Stats
        [HttpGet]
        [Produces("application/json")]
        public ContentResult GetTests()
        {
            // Instancio la clase
            Clases.Test Test = new Clases.Test();

            //Creo un nuevo test y obtengo el resultado
            Estadistica Estadistica = Test.Stats(_testRepository.CantHumanos(), _testRepository.CantMutantes());

            string jsonOutPut = "ADN:" + JsonSerializer.Serialize(Estadistica);

            return Content(jsonOutPut, "application/json");
        }

    }
}
