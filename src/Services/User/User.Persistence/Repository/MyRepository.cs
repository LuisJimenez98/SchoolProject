using Ardalis.Specification.EntityFrameworkCore;
using User.Application.Interfaces;

namespace User.Persistence.Repository
{
    public class MyRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public MyRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
