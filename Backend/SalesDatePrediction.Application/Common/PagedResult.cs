
namespace SalesDatePrediction.Application.Common;

public record PagedResult<T>(IEnumerable<T> Items, int TotalCount);
