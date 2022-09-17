using AutoMapper;
using Matter.Application.Specifications;
using MediatR;
using Qualification.Application.DTOs;
using Qualification.Application.Interfaces;
using Qualification.Application.Wrappers;
using Qualification.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualification.Application.Features.Queries.GetAll
{
    public class GetAllQuery: IRequest<PagedResponse<List<CalificacionDto>>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }

    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, PagedResponse<List<CalificacionDto>>>
    {
        private readonly IRepository<Calificacion> _repository;
        private readonly IMapper _mapper;
        public GetAllQueryHandler(IRepository<Calificacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedResponse<List<CalificacionDto>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var qualifications = await _repository.ListAsync(new PagedQualificationSpecification(request.PageSize, request.PageNumber));
            var qualificationsDto = _mapper.Map<List<CalificacionDto>>(qualifications);
            
            return new PagedResponse<List<CalificacionDto>>(qualificationsDto, request.PageNumber, request.PageSize); 
        }
    }
}
