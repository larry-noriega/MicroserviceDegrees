using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
}