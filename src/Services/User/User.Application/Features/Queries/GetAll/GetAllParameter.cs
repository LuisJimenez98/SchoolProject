using User.Application.Parameters;

namespace User.Application.Features.Queries.GetAll;
public class GetAllParameter: RequestParameter
{
    public string? Nombre { get; set; }
    public string? TipoColegio { get; set; }
}
