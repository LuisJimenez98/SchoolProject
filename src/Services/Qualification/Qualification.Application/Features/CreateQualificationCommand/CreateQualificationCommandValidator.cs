using FluentValidation;

namespace Qualification.Application.Features.CreateQualificationCommand;
public class CreateQualificationCommandValidator : AbstractValidator<CreateQualificationCommand>
{
    public CreateQualificationCommandValidator()
    {
        RuleFor(p => p.ColegioId).NotEmpty().WithMessage("{PropertyName} es requerido");

        RuleFor(p => p.MateriaId).NotEmpty().WithMessage("{PropertyName} es requerido");

        RuleFor(p => p.UsuarioId).NotEmpty().WithMessage("{PropertyName} es requerido");
        
        RuleFor(p => p.Nota).NotEmpty().WithMessage("{PropertyName} es requerido");
    }
}
