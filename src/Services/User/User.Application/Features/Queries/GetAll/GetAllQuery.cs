using AutoMapper;
using MediatR;
using User.Application.DTOs;
using User.Application.Interfaces;
using User.Application.Specifications;
using User.Application.Wrappers;
using User.Domain.Entity;

namespace User.Application.Features.Queries.GetAll;
public class GetAllQuery: IRequest<PagedResponse<List<UsuarioDto>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

}


public class GetAllQueryHandler : IRequestHandler<GetAllQuery, PagedResponse<List<UsuarioDto>>>
{
    private readonly IRepository<Usuario> _repository;
    private readonly IMapper _mapper;
    public GetAllQueryHandler(IRepository<Usuario> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<List<UsuarioDto>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var schools = await _repository.ListAsync(new PagedUserSpecification(request.PageSize, request.PageNumber));
        var schoolsDto = _mapper.Map<List<UsuarioDto>>(schools);

        return new PagedResponse<List<UsuarioDto>>(schoolsDto, request.PageNumber, request.PageSize);
    }


}