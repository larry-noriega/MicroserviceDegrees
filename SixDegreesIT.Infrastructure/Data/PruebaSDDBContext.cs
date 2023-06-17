using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SixDegreesIT.Core;


namespace SixDegreesIT.Infrastructure.Data
{
    public class PruebaSDDBContext : DbContext
    { 
        public PruebaSDDBContext(DbContextOptions<PruebaSDDBContext> options) : base(options)
        {
        }

        public DbSet<PruebasSD> PruebasSDs { get; set; }

       
    }

    public class PruebaSDDBContextFactory : IDesignTimeDbContextFactory<PruebaSDDBContext>
    {
        public PruebaSDDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PruebaSDDBContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PruebasSD;Integrated Security=True;MultipleActiveResultSets=True;");

            return new PruebaSDDBContext(optionsBuilder.Options);
        }
    }
}