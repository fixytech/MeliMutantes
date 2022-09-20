using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADNDetector.Models.Repository
{
    public interface ITestRepository
    {
        Task<Test> CreateTestAsync(Test test);
        IEnumerable<Test> GetTests();

        int CantHumanos();
        int CantMutantes();
    }
}
