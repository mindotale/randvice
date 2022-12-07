using Randvice.Contracts.V1.Advices;

namespace Randvice.Contracts.V1.Common;

public class PagedList<T>
{
    public int PageCount { get; set; }
    public int TotalItemCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
    public bool IsFirstPage { get; set; }
    public bool IsLastPage { get; set; }
    public int FirstItemOnPage { get; set; }
    public int LastItemOnPage { get; set; }
    public IEnumerable<AdviceResponse> Items { get; set; } = null!;
};
