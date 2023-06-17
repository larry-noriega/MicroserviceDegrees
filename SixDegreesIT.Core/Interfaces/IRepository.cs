namespace SixDegreesIT.Core.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T : EntityBase
    {        
        Task<IEnumerable<T>> List();
    }
}
