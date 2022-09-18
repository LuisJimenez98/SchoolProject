using AutoMapper;
using MediatR;
using User.Application.Interfaces;
using User.Application.Wrappers;
using User.Domain.Entity;

namespace User.Application.Features.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<Response<int>>
    {
        public int UsuarioId { get; set; }
        public string? NombreCompleto { get; set; }
        public string? UserName { get; set; }
        public string? password { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Rol { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Usuario> _repository;

        public UpdateUserCommandHandler(IMapper mapper, IRepository<Usuario> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UsuarioId);

            if (user == null)
                throw new KeyNotFoundException($"Resgistro no encontrado con el id {request.UsuarioId}");
            else
            {
                user.UsuarioId = request.UsuarioId;
                user.NombreCompleto = request.NombreCompleto;
                user.UserName = request.UserName;
                user.password = request.password;
                user.CorreoElectronico = request.CorreoElectronico;
                user.Rol = request.Rol;

                await _repository.UpdateAsync(user);
                return new Response<int>(user.UsuarioId);
            }

            
        }
    }
}
