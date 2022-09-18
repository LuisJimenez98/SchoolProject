using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Model.Matter.DTOs
{
    public class MateriaDto
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
