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

namespace Matter.Application.Features.Commands.DeleteCreateMatterCommand
{
    public class DeleteMatterCommand: IRequest<Response<int>>
    {
        public int MateriaId { get; set; }
    }

    public class DeleteMatterCommandHandler : IRequestHandler<DeleteMatterCommand, Response<int>>
    {
        private readonly IRepository<Materia> _repository;
        private readonly IMapper _mapper;
        
        public DeleteMatterCommandHandler(IRepository<Materia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<Response<int>> Handle(DeleteMatterCommand request, CancellationToken cancellationToken)
        {
            var matter = await _repository.GetByIdAsync(request.MateriaId);
            if (matter == null)
                throw new KeyNotFoundException($"Resgistro no encontrado con el id {request.MateriaId}");
            else
            {
                await _repository.DeleteAsync(matter);
                return new Response<int>(matter.MateriaId);
            }
        }
    }
}
