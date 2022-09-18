using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Model.School.Commands
{
    public class CreateSchoolCommand
    {
        public string? Nombre { get; set; }
        public string? TipoColegio { get; set; }
    }
}
