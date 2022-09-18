using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.NombreCompleto)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido")
                .MaximumLength(256)
                .WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.UserName)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido")
                .MaximumLength(128)
                .WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.password)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido")
                .MaximumLength(128)
                .WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.CorreoElectronico)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido")
                .EmailAddress()
                .WithMessage("{PropertyName} debe ser una dirección de correo electrónico válida")
                .MaximumLength(256)
                .WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Rol)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido")
                .MaximumLength(32)
                .WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

        }
    }
}
