using AutoMapper;
using MediatR;
using Qualification.Application.Interfaces;
using Qualification.Application.Wrappers;
using Qualification.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualification.Application.Features.UpdateQualificationCommand
{
    public class UpdateQualificationCommand: IRequest<Response<int>>
    {
        public int CalificacionId { get; set; }
        public int ColegioId { get; set; }
        public int MateriaId { get; set; }
        public int UsuarioId { get; set; }
        public double Nota { get; set; }
    }

    public class UpdateQualificationCommandHandler : IRequestHandler<UpdateQualificationCommand, Response<int>>
    {
        private readonly IRepository<Calificacion> _repository;
        private readonly IMapper _mapper;
        public UpdateQualificationCommandHandler(IRepository<Calificacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateQualificationCommand request, CancellationToken cancellationToken)
        {
            var qualification = await _repository.GetByIdAsync(request.CalificacionId);
            if (qualification == null)
                throw new KeyNotFoundException($"Resgistro no encontrado con el id {request.CalificacionId}");
            else
            {
                qualification.ColegioId = request.ColegioId;
                qualification.MateriaId = request.MateriaId;
                qualification.UsuarioId = request.UsuarioId;
                qualification.Nota = request.Nota;

                await _repository.UpdateAsync(qualification);
                return new Response<int>(qualification.CalificacionId);
            }
        }
    }
}
