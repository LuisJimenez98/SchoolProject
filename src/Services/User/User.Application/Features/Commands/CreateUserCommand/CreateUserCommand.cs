using AutoMapper;
using MediatR;
using User.Application.Interfaces;
using User.Application.Wrappers;
using User.Domain.Entity;

namespace User.Application.Features.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<Response<int>>
    {
        public string? NombreCompleto { get; set; }
        public string? UserName { get; set; }
        public string? password { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Rol { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Usuario> _repository;

        public CreateUserCommandHandler(IMapper mapper, IRepository<Usuario> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Usuario>(request);
            var data = await _repository.AddAsync(user);
            return new Response<int>(data.UsuarioId);
        }
    }
}
