using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.DTOs;
using User.Application.Features.Commands.CreateUserCommand;
using User.Domain.Entity;

namespace User.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateUserCommand, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
