using AutoMapper;
using MediatR;
using School.Application.Interfaces;
using School.Application.Wrappers;
using School.Domain.Entity;

namespace School.Application.Features.Commands.CreateSchoolCommand;
public class CreateSchoolCommand: IRequest<Response<int>>
{
    public string? Nombre { get; set; }
    public string? TipoColegio { get; set; }
}


public class CreateSchoolCommandHandler : IRequestHandler<CreateSchoolCommand, Response<int>>
{
    private readonly IRepository<Colegio> _repository;
    private readonly IMapper _mapper;
    public CreateSchoolCommandHandler(IRepository<Colegio> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
    {
        var school = _mapper.Map<Colegio>(request);
        var data = await _repository.AddAsync(school);

        return new Response<int>(data.ColegioId);
    }
}
