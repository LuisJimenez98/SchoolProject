using AutoMapper;
using MediatR;
using Qualification.Application.Interfaces;
using Qualification.Application.Wrappers;
using Qualification.Domain.Entity;

namespace Qualification.Application.Features.CreateQualificationCommand
{
    public class CreateQualificationCommand : IRequest<Response<int>>
    {
        public int ColegioId { get; set; }
        public int MateriaId { get; set; }
        public int UsuarioId { get; set; }
        public double Nota { get; set; }
    }

    public class CreateQualificationCommandHandler : IRequestHandler<CreateQualificationCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Calificacion> _repository;

        public CreateQualificationCommandHandler(IMapper mapper, IRepository<Calificacion> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(CreateQualificationCommand request, CancellationToken cancellationToken)
        {
            var qualification = _mapper.Map<Calificacion>(request);
            var data = await _repository.AddAsync(qualification);
            return new Response<int>(data.CalificacionId);
        }
    }
}
