using AutoMapper;
using MediatR;
using User.Application.Interfaces;
using User.Application.Wrappers;
using User.Domain.Entity;

namespace User.Application.Features.Commands.DeleteUserCommand
{
    public class DeleteUserCommand: IRequest<Response<int>>
    {
        public int UsuarioId { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<int>>
    {
        private readonly IRepository<Usuario> _repository;
        private readonly IMapper _mapper;
        
        public DeleteUserCommandHandler(IRepository<Usuario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UsuarioId);
            if (user == null)
                throw new KeyNotFoundException($"Resgistro no encontrado con el id {request.UsuarioId}");
            else
            {
                await _repository.DeleteAsync(user);
                return new Response<int>(user.UsuarioId);
            }
        }
    }
}
