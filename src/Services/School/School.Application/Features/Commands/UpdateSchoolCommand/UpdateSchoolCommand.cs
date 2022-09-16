using AutoMapper;
using MediatR;
using School.Application.Exceptions;
using School.Application.Interfaces;
using School.Application.Wrappers;
using School.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Features.Commands.UpdateSchoolCommand
{
    public class UpdateSchoolCommand : IRequest<Response<int>>
    {
        public int ColegioId { get; set; }
        public string? Nombre { get; set; }
        public string? TipoColegio { get; set; }
    }

    public class UpdateSchoolCommandHandler : IRequestHandler<UpdateSchoolCommand, Response<int>>
    {
        private readonly IRepository<Colegio> _repository;
        private readonly IMapper _mapper;
        public UpdateSchoolCommandHandler(IRepository<Colegio> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = await _repository.GetByIdAsync(request.ColegioId);
            if (school == null)
                throw new KeyNotFoundException($"Resgistro no encontrado con el id {request.ColegioId}");
            else
            {
                school.Nombre = request.Nombre;
                school.TipoColegio = request.TipoColegio;

                await _repository.UpdateAsync(school);
                return new Response<int>(school.ColegioId);
            }
        }
    }
}
