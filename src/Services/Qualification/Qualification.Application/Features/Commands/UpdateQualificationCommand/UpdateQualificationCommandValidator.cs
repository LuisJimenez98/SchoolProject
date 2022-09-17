using FluentValidation;

namespace Qualification.Application.Features.UpdateQualificationCommand
{
    public class UpdateQualificationCommandValidator : AbstractValidator<UpdateQualificationCommand>
    {
        public UpdateQualificationCommandValidator()
        {
            RuleFor(x => x.ColegioId)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido"); ;

            RuleFor(x => x.MateriaId)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido"); ;

            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido"); ;

            RuleFor(x => x.Nota)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido"); ;
        }
    }
}
