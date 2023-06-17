using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SixDegreesIT.Core;
using SixDegreesIT.Core.SQL;

namespace SixDegreesIT.Infrastructure.Data
{
    public class PersonDBContext : DbContext
    {
        private readonly IOptions<SQLSettings> _options;

        public PersonDBContext(IOptions<SQLSettings> options)
        {
            _options = options;
        }       

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (_options is null)
                throw new ArgumentNullException("Invalid settings", nameof(SQLSettings));

            optionsBuilder.UseSqlServer(_options.Value.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("PruebasSD");
        }
    }   
}