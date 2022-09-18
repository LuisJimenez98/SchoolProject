using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.DTOs;
using User.Application.Interfaces;
using User.Application.Wrappers;
using User.Domain.Entity;

namespace User.Application.Features.Queries.GetById
{
    public class GetByIdQuery : IRequest<Response<UsuarioDto>>
    {
        public int UsuarioId { get; set; }
    }


    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<UsuarioDto>>
    {
        private readonly IRepository<Usuario> _repository;
        private readonly IMapper _mapper;
        public GetByIdQueryHandler(IRepository<Usuario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<UsuarioDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UsuarioId);
            if (user == null)
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.UsuarioId}");
            else
            {
                var userDto = _mapper.Map<UsuarioDto>(user);
                return new Response<UsuarioDto>(userDto);
            }

        }
    }
}
