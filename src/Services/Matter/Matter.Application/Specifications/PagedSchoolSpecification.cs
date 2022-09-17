using Ardalis.Specification;
using Matter.Domain.Entity;

namespace Matter.Application.Specifications;
public class PagedSchoolSpecification : Specification<Materia>
{
    public PagedSchoolSpecification(int pageSize, int pageNumber)
    {
        Query.Skip((pageNumber-1) * pageSize).Take(pageSize);
    }
}
