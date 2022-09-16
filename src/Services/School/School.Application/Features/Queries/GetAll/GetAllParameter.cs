using School.Application.Parameters;

namespace School.Application.Features.Queries.GetAll;
public class GetAllParameter: RequestParameter
{
    public string? Nombre { get; set; }
    public string? TipoColegio { get; set; }
}
