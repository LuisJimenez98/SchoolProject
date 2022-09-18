namespace Api.Gateway.Model.Qualification.DTOs;
public class CalificacionDto
{
    public int CalificacionId { get; set; }
    public int ColegioId { get; set; }
    public int MateriaId { get; set; }
    public int UsuarioId { get; set; }
    public double Nota { get; set; }
}
