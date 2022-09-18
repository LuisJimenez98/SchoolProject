namespace Api.Gateway.Application.Behaviors.Commands.Matter
{
    public class UpdateMatterCommand
    {
        public int MateriaId { get; set; }
        public int ColegioId { get; set; }
        public string? Nombre { get; set; }
        public string? Area { get; set; }
        public int NumeroEstudiantes { get; set; }
        public string? DocenteAsignado { get; set; }
        public string? Curso { get; set; }
        public string? Paralelo { get; set; }
    }
}
