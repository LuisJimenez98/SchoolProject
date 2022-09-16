using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Features.Commands.UpdateSchoolCommand
{
    public class UpdateSchoolCommandValidator : AbstractValidator<UpdateSchoolCommand>
    {
        public UpdateSchoolCommandValidator()
        {
            RuleFor(p => p.ColegioId)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido");

            RuleFor(p => p.Nombre)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido")
                .MaximumLength(256).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.TipoColegio)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido")
                .MaximumLength(64).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
