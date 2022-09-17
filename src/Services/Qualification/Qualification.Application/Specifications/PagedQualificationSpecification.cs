using Ardalis.Specification;
using Qualification.Domain.Entity;

namespace Matter.Application.Specifications;
public class PagedQualificationSpecification : Specification<Calificacion>
{
    public PagedQualificationSpecification(int pageSize, int pageNumber)
    {
        Query.Skip((pageNumber-1) * pageSize).Take(pageSize);
    }
}
