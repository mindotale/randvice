using Microsoft.EntityFrameworkCore;
using Randvice.Core.Advices;
using X.PagedList;

namespace Randvice.Infrastructure.Persistence.Repositories;

public class AdviceRepository : IAdviceRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AdviceRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Advice advice, CancellationToken cancellationToken = default)
    {
        await _dbContext.Advices.AddAsync(advice, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var advice = await GetByIdAsync(id, cancellationToken);
        if (advice is null)
        {
            return false;
        }

        _dbContext.Advices.Remove(advice);
        return true;
    }

    public async Task<Advice?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Advices
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Advice?> GetRandomAsync(CancellationToken cancellationToken = default)
    {
        var count = await _dbContext.Advices.CountAsync(cancellationToken);
        var random = new Random();
        var index = random.Next(0, count);
        return await _dbContext.Advices
            .AsNoTracking()
            .Skip(index)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IPagedList<Advice>> GetWithPagination(
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber), "Must be positive");
        }
        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize), "Must be positive");
        }

        return await _dbContext.Advices
            .AsNoTracking()
            .ToPagedListAsync(pageNumber, pageSize, cancellationToken);
    }

    public async Task<bool> UpdateAsync(Advice advice, CancellationToken cancellationToken = default)
    {
        var exist = await GetByIdAsync(advice.Id, cancellationToken);
        if (exist is null)
        {
            return false;
        }

        _dbContext.Advices.Update(advice);
        return true;
    }
}
