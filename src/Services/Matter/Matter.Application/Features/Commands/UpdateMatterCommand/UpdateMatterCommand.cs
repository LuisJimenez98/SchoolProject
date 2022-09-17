using AutoMapper;
using Matter.Application.Interfaces;
using Matter.Application.Wrappers;
using Matter.Domain.Entity;
using MediatR;

namespace Matter.Application.Features.Commands.UpdateMatterCommand
{
    public class UpdateMatterCommand : IRequest<Response<int>>
    {
        public int MateriId { get; set; }
        public int ColegioId { get; set; }
        public string? Nombre { get; set; }
        public string? Area { get; set; }
        public int NumeroEstudiantes { get; set; }
        public string? DocenteAsignado { get; set; }
        public string? Curso { get; set; }
        public string? Paralelo { get; set; }
    }

    public class UpdateMatterCommandHandler : IRequestHandler<UpdateMatterCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Materia> _repository;

        public UpdateMatterCommandHandler(IMapper mapper, IRepository<Materia> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateMatterCommand request, CancellationToken cancellationToken)
        {
            var matter = await _repository.GetByIdAsync(request.MateriId);

            if (matter == null)
                throw new KeyNotFoundException($"Resgistro no encontrado con el id {request.MateriId}");
            else
            {
                matter.ColegioId = request.ColegioId;
                matter.Nombre = request.Nombre;
                matter.Area = request.Area;
                matter.NumeroEstudiantes = request.NumeroEstudiantes;
                matter.DocenteAsignado = request.DocenteAsignado;
                matter.Curso = request.Curso;
                matter.Paralelo = request.Paralelo;

                await _repository.UpdateAsync(matter);
                return new Response<int>(matter.MateriaId);
            }

            
        }
    }
}
