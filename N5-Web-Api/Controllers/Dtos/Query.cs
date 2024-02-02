using FluentValidation;
using Mapster;
using Sieve.Models;

namespace _Web_Api.Controllers.Dtos;

public class Query
{
    public string? Filters { get; set; }

    public string? Sorts { get; set; }

    public int? Page { get; set; }

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
