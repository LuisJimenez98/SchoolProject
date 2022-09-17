using Ardalis.Specification;
using AutoMapper;
using Matter.Application.Interfaces;
using Matter.Application.Wrappers;
using Matter.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matter.Application.Features.Commands.CreateMatterCommand
{
    public class CreateMatterCommand : IRequest<Response<int>>
    {
        public int ColegioId { get; set; }
        public string? Nombre { get; set; }
        public string? Area { get; set; }
        public int NumeroEstudiantes { get; set; }
        public string? DocenteAsignado { get; set; }
        public string? Curso { get; set; }
        public string? Paralelo { get; set; }
    }

    public class CreateMatterCommandHandler : IRequestHandler<CreateMatterCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Materia> _repository;

        public CreateMatterCommandHandler(IMapper mapper, IRepository<Materia> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(CreateMatterCommand request, CancellationToken cancellationToken)
        {
            var matter = _mapper.Map<Materia>(request);
            var data = await _repository.AddAsync(matter);
            return new Response<int>(data.MateriaId);
        }
    }
}
