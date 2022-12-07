using MapsterMapper;
using Randvice.Core.Common;
using Randvice.Core.Common.Models;
using X.PagedList;

namespace Randvice.Core.Advices;

public class AdviceService : IAdviceService
{
    private readonly IAdviceRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AdviceService(IAdviceRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Advice> CreateAdviceAsync(CreateAdviceCommand command, CancellationToken cancellationToken = default)
    {
        var advice = _mapper.Map<Advice>((Guid.NewGuid(), command));

        await _repository.AddAsync(advice, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);  
        
        return advice;
    }

    public async Task DeleteAdviceAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var deleted = await _repository.DeleteAsync(id, cancellationToken);
        if(!deleted)
        {
            throw new NotImplementedException();
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<Advice> GetAdviceByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var advice = await _repository.GetByIdAsync(id, cancellationToken);
        if(advice is null)
        {
            throw new NotImplementedException();
        }
        return advice;
    }

    public Task<IPagedList<Advice>> GetAdvicesWithPaginationAsync(
        PaginationFilter paginationFilter,
        CancellationToken cancellationToken = default)
    {
        var advices = _repository.GetWithPagination(
            paginationFilter.PageNumber,
            paginationFilter.PageSize,
            cancellationToken);
        return advices;
    }

    public async Task<Advice> GetRandomAdviceAsync(CancellationToken cancellationToken = default)
    {
        var advice = await _repository.GetRandomAsync(cancellationToken);
        if (advice is null)
        {
            throw new NotImplementedException();
        }
        return advice;
    }

    public async Task<Advice> UpdateAdviceAsync(
        UpdateAdviceCommand command,
        CancellationToken cancellationToken = default)
    {
        var advice = _mapper.Map<Advice>(command);
        var updated = await _repository.UpdateAsync(advice, cancellationToken);
        if(!updated)
        {
            throw new NotImplementedException();
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return advice;
    }
}
