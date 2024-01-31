namespace N5_Web_Api.Controllers.Dtos;

/// <summary>
/// Resultado de una consulta que retorna un listado.
/// </summary>
/// <typeparam name="T">Recurso consultado.</typeparam>
public class ListResult<T>
{
    /// <summary>
    /// Colección/Array de recursos.
    /// </summary>
    public IEnumerable<T> Results { get; set; }

    /// <summary>
    /// Tamaño de página.
    /// </summary>
    /// <example>50</example>
    public long PageSize { get; set; }

    /// <summary>
    /// Número de página.
    /// </summary>
    /// <example>1</example>
    public int PageNumber { get; set; }

    /// <summary>
    /// Total de recursos en base a los criterios proporcionados (sumando todas las páginas).
    /// </summary>
    public long Total { get; set; }

}
