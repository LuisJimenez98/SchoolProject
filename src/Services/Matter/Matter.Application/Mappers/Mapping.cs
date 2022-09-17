using AutoMapper;
using Matter.Application.DTOs;
using Matter.Application.Features.Commands.CreateMatterCommand;
using Matter.Domain.Entity;

namespace Matter.Application.Mappers;
public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<CreateMatterCommand, Materia>();
        CreateMap<Materia, MateriaDto>();
    }
}
