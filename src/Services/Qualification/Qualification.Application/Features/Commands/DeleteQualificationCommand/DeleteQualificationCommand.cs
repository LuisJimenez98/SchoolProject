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

namespace Qualification.Application.Features.DeleteQualificationCommand
{
    public class DeleteQualificationCommand: IRequest<Response<int>>
    {
        public int CalificacionId { get; set; }
    }

    public class DeleteQualificationCommandHandler : IRequestHandler<DeleteQualificationCommand, Response<int>>
    {
        private readonly IRepository<Calificacion> _repository;
        private readonly IMapper _mapper;
        public DeleteQualificationCommandHandler(IRepository<Calificacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteQualificationCommand request, CancellationToken cancellationToken)
        {
            var qualification = await _repository.GetByIdAsync(request.CalificacionId);
            if (qualification == null)
                throw new KeyNotFoundException($"Resgistro no encontrado con el id {request.CalificacionId}");
            else
            {
                await _repository.DeleteAsync(qualification);
                return new Response<int>(qualification.CalificacionId);
            }
        }
    }
}
