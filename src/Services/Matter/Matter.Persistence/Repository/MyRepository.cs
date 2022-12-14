using Ardalis.Specification.EntityFrameworkCore;
using Matter.Application.Interfaces;

namespace Matter.Persistence.Repository
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
