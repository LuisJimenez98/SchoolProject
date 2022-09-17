using AutoMapper;
using Matter.Application.DTOs;
using Matter.Application.Interfaces;
using Matter.Application.Wrappers;
using Matter.Domain.Entity;
using MediatR;
namespace Matter.Application.Features.Queries.GetById;
public class GetByIdQuery: IRequest<Response<MateriaDto>>
{
    public int MateriaId { get; set; }
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<MateriaDto>>
{
    private readonly IRepository<Materia> _repository;
    private readonly IMapper _mapper;
    public GetByIdQueryHandler(IRepository<Materia> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<MateriaDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var matter = await _repository.GetByIdAsync(request.MateriaId);
        if (matter == null)
            throw new KeyNotFoundException($"Registro no encontrado con el id {request.MateriaId}");
        else
        {
            var matterDto = _mapper.Map<MateriaDto>(matter);
            return new Response<MateriaDto>(matterDto);
        }

    }
}
