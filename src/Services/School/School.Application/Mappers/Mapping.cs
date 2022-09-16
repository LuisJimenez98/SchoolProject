using AutoMapper;
using School.Application.Features.Commands.CreateSchoolCommand;
using School.Domain.Entity;

namespace School.Application.Mappers;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<CreateSchoolCommand, Colegio>();
    }
}
