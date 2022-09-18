namespace Api.Gateway.Application.Behaviors.Commands.Qualification;
public class CreateQualificationCommand
{
    public int ColegioId { get; set; }
    public int MateriaId { get; set; }
    public int UsuarioId { get; set; }
    public double Nota { get; set; }
}

