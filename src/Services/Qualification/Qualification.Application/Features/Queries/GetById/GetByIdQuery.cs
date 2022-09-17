using AutoMapper;
using MediatR;
using Qualification.Application.DTOs;
using Qualification.Application.Interfaces;
using Qualification.Application.Wrappers;
using Qualification.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualification.Application.Features.Queries.GetById
{
    public class GetByIdQuery : IRequest<Response<CalificacionDto>>
    {
        public int CalificacionId { get; set; }
    }

    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<CalificacionDto>>
    {
        private readonly IRepository<Calificacion> _repository;
        private readonly IMapper _mapper;
        public GetByIdQueryHandler(IRepository<Calificacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<CalificacionDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var qualification = await _repository.GetByIdAsync(request.CalificacionId);

            if (qualification == null)
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.CalificacionId}");
            else
            {
                var qualificationDto = _mapper.Map<CalificacionDto>(qualification);
                return new Response<CalificacionDto>(qualificationDto);
            }
        }
    }
}
