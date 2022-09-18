using AutoMapper;
using Matter.Application.DTOs;
using Matter.Application.Interfaces;
using Matter.Application.Specifications;
using Matter.Application.Wrappers;
using Matter.Domain.Entity;
using MediatR;

namespace Matter.Application.Features.Queries.GetAll
{
    public class GetAllQuery : IRequest<PagedResponse<List<MateriaDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, PagedResponse<List<MateriaDto>>>
    {
        private readonly IRepository<Materia> _repository;
        private readonly IMapper _mapper;
        public GetAllQueryHandler(IRepository<Materia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<MateriaDto>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var matters = await _repository.ListAsync(new PagedMatterSpecification(request.PageSize, request.PageNumber));
            var mattersDto = _mapper.Map<List<MateriaDto>>(matters);

            return new PagedResponse<List<MateriaDto>>(mattersDto, request.PageNumber, request.PageSize);
        }

    }
}
