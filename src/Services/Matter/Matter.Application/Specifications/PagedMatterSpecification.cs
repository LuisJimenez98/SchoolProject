using Ardalis.Specification;
using Matter.Domain.Entity;

namespace Matter.Application.Specifications;
public class PagedMatterSpecification : Specification<Materia>
{
    public PagedMatterSpecification(int pageSize, int pageNumber)
    {
        Query.Skip((pageNumber-1) * pageSize).Take(pageSize);
    }
}
