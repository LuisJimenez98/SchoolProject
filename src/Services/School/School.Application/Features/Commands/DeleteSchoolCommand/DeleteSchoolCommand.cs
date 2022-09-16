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

namespace School.Application.Features.Commands.DeleteSchoolCommand
{
    public class DeleteSchoolCommand : IRequest<Response<int>>
    {
        public int ColegioId { get; set; }
    }

    public class DeleteSchoolCommandHandler : IRequestHandler<DeleteSchoolCommand, Response<int>>
    {
        private readonly IRepository<Colegio> _repository;
        private readonly IMapper _mapper;
        public DeleteSchoolCommandHandler(IRepository<Colegio> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }   

        public async Task<Response<int>> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = await _repository.GetByIdAsync(request.ColegioId);
            if (school == null)
                throw new KeyNotFoundException($"Resgistro no encontrado con el id {request.ColegioId}");
            else
            {
                await _repository.DeleteAsync(school);
                return new Response<int>(school.ColegioId);
            }
        }
    }
}
