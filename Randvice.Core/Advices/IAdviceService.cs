using Randvice.Core.Common.Models;
using X.PagedList;

namespace Randvice.Core.Advices;

public interface IAdviceService
{
    public Task<Advice> GetAdviceByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<Advice> GetRandomAdviceAsync(CancellationToken cancellationToken = default);

    public Task<IPagedList<Advice>> GetAdvicesWithPaginationAsync(
        PaginationFilter paginationFilter,
        CancellationToken cancellationToken = default);

    public Task<Advice> CreateAdviceAsync(
        CreateAdviceCommand command,
        CancellationToken cancellationToken = default);

    public Task<Advice> UpdateAdviceAsync(
        UpdateAdviceCommand command,
        CancellationToken cancellationToken = default);

    public Task DeleteAdviceAsync(Guid id, CancellationToken cancellationToken = default);
}
