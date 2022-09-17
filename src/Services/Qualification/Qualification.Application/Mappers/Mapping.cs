using AutoMapper;
using Qualification.Application.Features.CreateQualificationCommand;
using Qualification.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualification.Application.Mappers
{
    public class Mapping: Profile
    {
        public Mapping()
        {
            CreateMap<CreateQualificationCommand, Calificacion>();
        }
    }
}
