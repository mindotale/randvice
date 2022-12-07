using X.PagedList;

namespace Randvice.Core.Advices;

public interface IAdviceRepository
{
    public Task<Advice?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<IPagedList<Advice>> GetWithPagination(
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default);

    public Task<Advice?> GetRandomAsync(CancellationToken cancellationToken = default);

    public Task AddAsync(Advice advice, CancellationToken cancellationToken = default);

    public Task<bool> UpdateAsync(Advice advice, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
