using AutoMapper;
using Matter.Application.Features.Commands.CreateMatterCommand;
using Matter.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matter.Application.Mappers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateMatterCommand, Materia>();
        }
    }
}
