using AutoMapper;
using MediatR;
using School.Application.Exceptions;
using School.Application.Interfaces;
using School.Application.Wrappers;
using School.Domain.Entity;
using System;
namespace Api.Gateway.Model.School.Commands
{
    public class DeleteSchoolCommand
    {
        public int ColegioId { get; set; }
    }

}
