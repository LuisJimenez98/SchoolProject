using Ardalis.Specification;
using User.Domain.Entity;

namespace User.Application.Specifications;
public class PagedMatterSpecification : Specification<Usuario>
{
    public PagedMatterSpecification(int pageSize, int pageNumber)
    {
        Query.Skip((pageNumber-1) * pageSize).Take(pageSize);
    }
}
