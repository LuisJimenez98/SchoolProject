namespace Api.Gateway.Application.Behaviors.Commands.User
{
    public class UpdateUserCommand
    {
        public int UsuarioId { get; set; }
        public string? NombreCompleto { get; set; }
        public string? UserName { get; set; }
        public string? password { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Rol { get; set; }
    }

}
