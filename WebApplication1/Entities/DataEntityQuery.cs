using MediatR;

namespace WebApplication1.Entities
{
    public class DataEntityQuery : DataEntity, IRequest<IReadOnlyCollection<DataEntity>>
    {
    }
}
