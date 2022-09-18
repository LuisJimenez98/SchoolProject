namespace Api.Gateway.Model.School.Commands
{
    public class UpdateSchoolCommand
    {
        public int ColegioId { get; set; }
        public string? Nombre { get; set; }
        public string? TipoColegio { get; set; }
    }
}
