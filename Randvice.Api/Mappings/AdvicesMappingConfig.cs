using Mapster;
using Randvice.Contracts.V1.Advices;
using Randvice.Core.Advices;
using X.PagedList;

namespace Randvice.Api.Mappings;
public class AdvicesMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAdviceRequest, CreateAdviceCommand>();
        config.NewConfig<(Guid id, UpdateAdviceRequest request), UpdateAdviceCommand>()
            .Map(d => d.Id, s => s.id)
            .Map(d => d.Text, s => s.request.Text);

        config.NewConfig<(Guid id, CreateAdviceCommand command), Advice>()
            .Map(d => d.Id, s => s.id)
            .Map(d => d.Text, s => s.command.Text);
        config.NewConfig<UpdateAdviceCommand, Advice>();

        config.NewConfig<Advice, AdviceResponse>();
        config.NewConfig<IPagedList<Advice>, Contracts.V1.Common.PagedList<AdviceResponse>>()
            .Map(d => d.Items, s => s)
            .Map(d => d, s => s);
    }
}
