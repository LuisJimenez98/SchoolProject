using Ardalis.Specification;

namespace User.Application.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
    }

    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
    {
    }
}
