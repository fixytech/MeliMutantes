using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;

namespace ADNDetector.Models
{
    public class DbLaboratorioContext : DbContext
    {
        public DbLaboratorioContext(DbContextOptions<DbLaboratorioContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DbSet<Test> Tests { get; set; }
    }
}
