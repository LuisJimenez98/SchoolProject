using Ardalis.Specification;
using User.Domain.Entity;

namespace User.Application.Specifications;
public class PagedUserSpecification : Specification<Usuario>
{
    public PagedUserSpecification(int pageSize, int pageNumber)
    {
        Query.Skip((pageNumber-1) * pageSize).Take(pageSize);
    }
}
