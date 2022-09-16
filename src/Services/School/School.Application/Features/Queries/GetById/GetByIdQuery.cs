using AutoMapper;
using MediatR;
using School.Application.DTOs;
using School.Application.Interfaces;
using School.Application.Wrappers;
using School.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Features.Queries.GetById
{
    public class GetByIdQuery : IRequest<Response<ColegioDto>>
    {
        public int ColegioId { get; set; }
    }


    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<ColegioDto>>
    {
        private readonly IRepository<Colegio> _repository;
        private readonly IMapper _mapper;
        public GetByIdQueryHandler(IRepository<Colegio> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<ColegioDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var school = await _repository.GetByIdAsync(request.ColegioId);
            if (school == null)
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.ColegioId}");
            else
            {
                var schoolDto = _mapper.Map<ColegioDto>(school);
                return new Response<ColegioDto>(schoolDto);
            }

        }
    }
}
