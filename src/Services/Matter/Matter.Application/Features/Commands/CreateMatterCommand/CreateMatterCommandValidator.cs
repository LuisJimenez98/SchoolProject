using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matter.Application.Features.Commands.CreateMatterCommand
{
    public class CreateMatterCommandValidator : AbstractValidator<CreateMatterCommand>
    {
        public CreateMatterCommandValidator()
        {
            RuleFor(p => p.ColegioId)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido");

            RuleFor(p => p.Nombre)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido")
                .MaximumLength(256)
                .WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Area)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido")
                .MaximumLength(128)
                .WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.NumeroEstudiantes)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido");

            RuleFor(p => p.DocenteAsignado)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido")
                .MaximumLength(512)
                .WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Curso)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido")
                .MaximumLength(64)
                .WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Paralelo)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido")
                .MaximumLength(16)
                .WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
