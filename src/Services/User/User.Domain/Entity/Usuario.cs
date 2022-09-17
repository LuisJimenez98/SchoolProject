using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Entity
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string? NombreCompleto { get; set; }
        public string? UserName { get; set; }
        public string? password { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Rol { get; set; }
    }
}
