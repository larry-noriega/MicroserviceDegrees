using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SixDegreesIT.Core;
using SixDegreesIT.Core.Interfaces;
using SixDegreesIT.Core.SQL;
using SixDegreesIT.Infrastructure.Data;

namespace SixDegreesIT.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable
        where T : EntityBase
    {
        private readonly PersonDBContext _dbContext;

        public Repository(IOptions<SQLSettings> options)
        {
            _dbContext = new PersonDBContext(options);
        }

        public async Task<IEnumerable<T>> List()
        {           
            return (await _dbContext.Set<T>().ToListAsync())
                .OrderBy(document => document.Id)
                .ToList();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
