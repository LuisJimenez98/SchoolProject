using Ardalis.Specification;

namespace Qualification.Application.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
    }

    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
    {
    }
}
