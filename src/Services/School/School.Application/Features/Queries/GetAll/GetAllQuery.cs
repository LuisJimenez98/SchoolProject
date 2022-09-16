using AutoMapper;
using MediatR;
using School.Application.DTOs;
using School.Application.Interfaces;
using School.Application.Specifications;
using School.Application.Wrappers;
using School.Domain.Entity;

namespace School.Application.Features.Queries.GetAll;
public class GetAllQuery: IRequest<PagedResponse<List<ColegioDto>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

}


public class GetAllQueryHandler : IRequestHandler<GetAllQuery, PagedResponse<List<ColegioDto>>>
{
    private readonly IRepository<Colegio> _repository;
    private readonly IMapper _mapper;
    public GetAllQueryHandler(IRepository<Colegio> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<List<ColegioDto>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var schools = await _repository.ListAsync(new PagedSchoolSpecification(request.PageSize, request.PageNumber));
        var schoolsDto = _mapper.Map<List<ColegioDto>>(schools);

        return new PagedResponse<List<ColegioDto>>(schoolsDto, request.PageNumber, request.PageSize);
    }


}