using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ADNDetector.Models.Repository
{
    public class TestRepository : ITestRepository
    {

        protected readonly DbLaboratorioContext _context;
        public TestRepository(DbLaboratorioContext context) => _context = context;

        public IEnumerable<Test> GetTests()
        {
            return _context.Tests.ToList();
        }

        public int CantHumanos()
        {
            return _context.Tests.Where(b => b.Resultado != true).Count();
        }

        public int CantMutantes()
        {
            return _context.Tests.Where(b => b.Resultado == true).Count();
        }


        public async Task<Test> CreateTestAsync(Test test)
        {
            await _context.Set<Test>().AddAsync(test);
            await _context.SaveChangesAsync();
            return test;
        }

    }

}
