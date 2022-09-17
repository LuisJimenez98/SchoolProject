using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualification.Domain.Entity
{
    public class Calificacion
    {
        public int CalificacionId { get; set; }
        public int ColegioId { get; set; }
        public int MateriaId { get; set; }
        public int UsuarioId { get; set; }
        public double Nota { get; set; }
    }
}
