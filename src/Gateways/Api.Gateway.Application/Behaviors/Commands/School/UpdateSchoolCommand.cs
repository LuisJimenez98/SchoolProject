namespace Api.Gateway.Application.Behaviors.Commands.School
{
    public class UpdateSchoolCommand
    {
        public int ColegioId { get; set; }
        public string? Nombre { get; set; }
        public string? TipoColegio { get; set; }
    }
}
