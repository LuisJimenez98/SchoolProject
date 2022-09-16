using Ardalis.Specification;
using School.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Specifications
{
    public class PagedSchoolSpecification : Specification<Colegio>
    {
        public PagedSchoolSpecification(int pageSize, int pageNumber)
        {
            Query.Skip((pageNumber-1) * pageSize).Take(pageSize);
        }
    }
}
