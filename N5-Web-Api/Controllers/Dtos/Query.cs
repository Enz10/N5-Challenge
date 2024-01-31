using FluentValidation;
using Mapster;
using Sieve.Models;

namespace _Web_Api.Controllers.Dtos;

public class Query
{
    /// <summary>
    /// Filtros.
    /// </summary>
    /// <example>Id==20</example>
    public string Filters { get; set; }

    /// <summary>
    /// Criterios de ordenamiento.
    /// </summary>
    /// <example>-CreationDate</example>
    public string Sorts { get; set; }

    /// <summary>
    /// Número de página.<br/>
    /// Empieza a contar en 1.
    /// </summary>
    /// <example>1</example>
    public int? Page { get; set; }

    /// <summary>
    /// Tamaño de página.
    /// </summary>
    /// <example>50</example>
    public int? PageSize { get; set; }

    public static void ConfigureMapper(TypeAdapterConfig config)
    {
        config.ForType<Query, SieveModel>();
    }

    public sealed class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            RuleFor(r => r.Page)
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(int.MaxValue);

            RuleFor(r => r.PageSize)
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(int.MaxValue);
        }
    }
}
