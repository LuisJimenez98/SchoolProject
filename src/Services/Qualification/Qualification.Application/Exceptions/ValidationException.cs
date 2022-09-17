using FluentValidation.Results;

namespace Qualification.Application.Exceptions;
public class ValidationException : Exception
{
    public List<string> Errors { get; set; }
    public ValidationException() : base("Se ha producido uno o más errores de validación")
    {
        Errors = new List<string>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        foreach (var failure in failures)
            this.Errors.Add(failure.ErrorMessage);
    }
}
